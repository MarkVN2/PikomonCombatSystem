using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class PikomonHUD : MonoBehaviour
{
    [Header("Pikomon Player Info Display")]
    [SerializeField] private TextMeshProUGUI pikomonNameText;
    [SerializeField] private GameObject playerHealthSlider;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private Image pikomonPortrait;
    
    [Header("Abilities Panel")]
    [SerializeField] private Transform abilitiesContainer;
    [SerializeField] private GameObject abilityButtonPrefab;

    [Header("CPU Pikomon")]
    [SerializeField] private GameObject cpuHealthSlider;
    [SerializeField] private TextMeshProUGUI cpuNameText;
    [SerializeField] private TextMeshProUGUI cpuHealthText;

    [Header("BattleInfo")]

    private PikoController currentPikoController;
    private Pikomon cpuPikomon;
    private List<Button> abilityButtons = new List<Button>();
    
    public void Initialize(PikoController playerController)
    {
        currentPikoController = playerController;
        cpuPikomon = GameManager.Instance.GetCPUPikomon();
        UpdateDisplay();
        CreateAbilityButtons();
    }
    
    public void UpdateDisplay()
    {
        if (currentPikoController?.GetPikomon() == null || cpuPikomon == null) return;
        
        Pikomon pikomon = currentPikoController.GetPikomon();
        
        if (pikomonNameText != null)
            pikomonNameText.text = pikomon.Name;
        if (cpuNameText != null)
            cpuNameText.text = cpuPikomon.Name;

        if (playerHealthSlider != null)
        {
            playerHealthSlider.GetComponent<LifeLevel>().SetHealthPercentage(pikomon.Health / pikomon.MaxHealth);
        }
        if (cpuHealthSlider != null)
        {
            cpuHealthSlider.GetComponent<LifeLevel>().SetHealthPercentage(cpuPikomon.Health / cpuPikomon.MaxHealth);
        }

        if (healthText != null)
            healthText.text = $"{pikomon.Health:F0}/{pikomon.MaxHealth:F0}";
        if (cpuHealthText != null)
            cpuHealthText.text =$"{cpuPikomon.Health:F0}/{cpuPikomon.MaxHealth:F0}" ;
        if (pikomonPortrait != null && pikomon.BackSprite != null)
            pikomonPortrait.sprite = pikomon.BackSprite;
    }

    private void CreateAbilityButtons()
    {
        if (currentPikoController?.GetPikomon() == null || abilitiesContainer == null || abilityButtonPrefab == null)
            return;

        foreach (var button in abilityButtons)
        {
            if (button != null) Destroy(button.gameObject);
        }
        abilityButtons.Clear();

        var pikomon = currentPikoController.GetPikomon();

        foreach (var power in pikomon.Powers)
        {
            // Debug.Log($"Creating button for: {power.Name}");

            GameObject buttonObj = Instantiate(abilityButtonPrefab, abilitiesContainer);
            Button button = buttonObj.GetComponent<Button>();

            if (button != null)
            {
                SetupAbilityButton(button, power);
                abilityButtons.Add(button);
            }
            else
            {
                Debug.LogError("Button prefab doesn't have Button component!");
            }
        }
    }

    private void SetupAbilityButton(Button button, Power power)
    {
        PowerButtonController controller = button.GetComponent<PowerButtonController>();
        if (controller != null)
        {
            controller.SetAbilityName(power.Name);
            if (power.MaxCharges <= 0)
            {
                controller.SetCharges("∞");
            }
            else {
                controller.SetCharges($"{power.CurrentCharges}/{power.MaxCharges}");
            }
        }
        else 
        {
            Debug.LogError("No Controller Found on Button!");
        }

        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() => OnAbilityClicked(power));

        if (power.MaxCharges <= 0)
        {
            button.interactable = true;
        }
        else
        {
            button.interactable = power.CurrentCharges > 0 && power.MaxCharges > 0;
        }
    }
    
   private void OnAbilityClicked(Power power)
{
    if (GameManager.Instance.CurrentGameState != IGameState.Player_Turn)
    {
        Debug.Log("Not player's turn!");
        return;
    }
    
    Pikomon player = currentPikoController.GetPikomon();
    
    Power playerPower = player.Powers.FirstOrDefault(p => p.GetType() == power.GetType());
    
    if (playerPower != null)
    {
        bool canUse = (playerPower.MaxCharges <= 0) || (playerPower.CurrentCharges > 0);
        
        if (canUse)
        {
            GameManager.Instance.PlayerAttack(playerPower);
            UpdateDisplay();
            CreateAbilityButtons(); 
        }
        else
        {
            Debug.Log($"Power {power.Name} has no charges left!");
        }
    }
    else
    {
        Debug.Log($"Power {power.Name} not found!");
    }
}
    public void RefreshDisplay()
    {
        UpdateDisplay();

        for (int i = 0; i < abilityButtons.Count && i < currentPikoController.GetPikomon().Powers.Count; i++)
        {
            var power = currentPikoController.GetPikomon().Powers[i];
            var button = abilityButtons[i];

            PowerButtonController controller = button.GetComponent<PowerButtonController>();
            if (controller != null)
            {
                controller.SetAbilityName(power.Name);
                if (power.MaxCharges <= 0)
                {
                    controller.SetCharges("∞");
                    button.interactable = true; // Always usable
                }
                else
                {
                    controller.SetCharges($"{power.CurrentCharges}/{power.MaxCharges}");
                    button.interactable = power.CurrentCharges > 0;
                }
            }
        }
    }
}