using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.InputSystem;

public class BattleLogUI : MonoBehaviour
{
    [Header("Battle Log UI")]
    [SerializeField] private GameObject battleLogPanel;
    [SerializeField] private TextMeshProUGUI actionText;
    [SerializeField] private Button continueButton;
    
    [Header("Animation Settings")]
    [SerializeField] private float fadeInDuration = 0.3f;
    [SerializeField] private CanvasGroup canvasGroup;
    
    [Header("Input")]
    [SerializeField] private InputActionReference continueAction;
    
    private bool isWaitingForInput = false;
    private System.Action onContinueCallback;
    
    private void Start()
    {
        if (continueButton != null)
        {
            continueButton.onClick.AddListener(OnContinuePressed);
        }
        
        if (battleLogPanel != null)
        {
            battleLogPanel.SetActive(false);
        }
        
        if (continueAction != null)
        {
            continueAction.action.performed += OnContinueInput;
        }
    }
    
    private void OnEnable()
    {
        if (continueAction != null)
        {
            continueAction.action.Enable();
        }
    }
    
    private void OnDisable()
    {
        if (continueAction != null)
        {
            continueAction.action.Disable();
        }
    }
    
    private void OnDestroy()
    {
        if (continueAction != null)
        {
            continueAction.action.performed -= OnContinueInput;
        }
    }
    
    private void OnContinueInput(InputAction.CallbackContext context)
    {
        if (isWaitingForInput)
        {
            OnContinuePressed();
        }
    }
    
    private void Update()
    {
        if (continueAction == null && isWaitingForInput)
        {
            if (Keyboard.current?.anyKey.wasPressedThisFrame == true ||
                Mouse.current?.leftButton.wasPressedThisFrame == true)
            {
                OnContinuePressed();
            }
        }
    }
    
    public void ShowAttackLog(Pikomon attacker, string attackName, System.Action onComplete = null)
    {
        onContinueCallback = onComplete;
        isWaitingForInput = true;

        if (actionText != null)
            actionText.text = $"{attacker.Name} uses {attackName}!";
        
        StartCoroutine(ShowPanelCoroutine());
    }
    
    private IEnumerator ShowPanelCoroutine()
    {
        if (battleLogPanel != null)
        {
            battleLogPanel.SetActive(true);
        }

        if (canvasGroup != null)
        {
            canvasGroup.alpha = 0f;
            float elapsedTime = 0f;

            while (elapsedTime < fadeInDuration)
            {
                elapsedTime += Time.deltaTime;
                canvasGroup.alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeInDuration);
                yield return null;
            }

            canvasGroup.alpha = 1f;
        }
    }
    
    private void OnContinuePressed()
    {
        if (!isWaitingForInput) return;
        
        isWaitingForInput = false;
        StartCoroutine(HidePanelCoroutine());
    }
    
    private IEnumerator HidePanelCoroutine()
    {
        if (canvasGroup != null)
        {
            float elapsedTime = 0f;
            
            while (elapsedTime < fadeInDuration)
            {
                elapsedTime += Time.deltaTime;
                canvasGroup.alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeInDuration);
                yield return null;
            }
            
            canvasGroup.alpha = 0f;
        }
        
        if (battleLogPanel != null)
        {
            battleLogPanel.SetActive(false);
        }
        
        onContinueCallback?.Invoke();
    }
    
    public bool IsShowingLog()
    {
        return isWaitingForInput;
    }
}