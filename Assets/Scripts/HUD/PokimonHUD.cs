using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class PikomonHUD : MonoBehaviour
{
    [Header("Pikomon Info Display")]
    [SerializeField] private TextMeshProUGUI pikomonNameText;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private Image pikomonPortrait;
    
    [Header("Abilities Panel")]
    [SerializeField] private Transform abilitiesContainer;
    [SerializeField] private GameObject abilityButtonPrefab;
    
    private PikoController currentPikoController;
    private List<Button> abilityButtons = new List<Button>();
    
    public void Initialize(PikoController playerController)
    {
        currentPikoController = playerController;
        UpdateDisplay();
        CreateAbilityButtons();
    }
    
    public void UpdateDisplay()
    {
        if (currentPikoController?.GetPikomon() == null) return;
        
        var pikomon = currentPikoController.GetPikomon();
        
        if (pikomonNameText != null)
            pikomonNameText.text = pikomon.Name;
        
        if (healthSlider != null)
        {
            healthSlider.maxValue = pikomon.MaxHealth;
            healthSlider.value = pikomon.Health;
        }
        
        if (healthText != null)
            healthText.text = $"{pikomon.Health:F0}/{pikomon.MaxHealth:F0}";
        
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
      TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
        if (buttonText != null)
        {
            string textToSet = $"{power.Name}\n({power.CurrentCharges}/{power.MaxCharges})";
            buttonText.text = textToSet;
            Debug.Log($"Set button text to: {textToSet}");
        }
        else
        {
            Debug.LogError($"No TextMeshProUGUI found in button for {power.Name}");
            
            Text legacyText = button.GetComponentInChildren<Text>();
            if (legacyText != null)
            {
                legacyText.text = $"{power.Name}\n({power.CurrentCharges}/{power.MaxCharges})";
                Debug.Log("Used legacy Text component instead");
            }
        }
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() => OnAbilityClicked(power));
        
        button.interactable = power.CurrentCharges > 0;
    }    
    
   private void OnAbilityClicked(Power power)
{
    if (GameManager.Instance.CurrentGameState != IGameState.Player_Turn)
    {
        Debug.Log("Not player's turn!");
        return;
    }
    
    Pikomon player = currentPikoController.GetPikomon();
    Pikomon cpuPikomon = GameManager.Instance.GetCPUPikomon();
    
    Power playerPower = player.Powers.FirstOrDefault(p => p.GetType() == power.GetType());
    
    if (playerPower != null && playerPower.CurrentCharges > 0)
    {
        playerPower.UsePower(player, cpuPikomon);
        Debug.Log($"Player uses {playerPower.Name}!");
        
        UpdateDisplay();
        CreateAbilityButtons(); 
        GameManager.Instance.ChangeGameState(IGameState.CPU_Turn);
    }
    else
    {
        Debug.Log($"Power {power.Name} has no charges left or not found!");
    }
}
    public void RefreshDisplay()
    {
        UpdateDisplay();
        
        for (int i = 0; i < abilityButtons.Count && i < currentPikoController.GetPikomon().Powers.Count; i++)
        {
            var power = currentPikoController.GetPikomon().Powers[i];
            var button = abilityButtons[i];
            
            TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
            if (buttonText != null)
            {
                buttonText.text = $"{power.Name}\n({power.CurrentCharges}/{power.MaxCharges})";
            }
            
            button.interactable = power.CurrentCharges > 0;
        }
    }
}