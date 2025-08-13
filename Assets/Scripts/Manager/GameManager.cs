using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public IGameState CurrentGameState { get; private set; }

    [Header("UI")]
    [SerializeField] private PikomonHUD playerHUD;
    [SerializeField] private BattleLogUI battleLogUI;
    [SerializeField] private Button restartButton;
    
    [Header("Battle Setup")]
    public Transform playerSpawnPoint;
    public Transform cpuSpawnPoint;

    private PikoController playerController;
    private PikoController cpuController;
    private Pikomon cpu_pikomon;
    private Pikomon player_pikomon;
    private bool cpuActionExecuted = false;
    public Pikomon GetCPUPikomon() => cpu_pikomon;
    public Pikomon GetPlayerPikomon() => player_pikomon;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
         if (restartButton != null)
        {
            restartButton.gameObject.SetActive(false);
            restartButton.onClick.AddListener(OnRestartButtonClicked);
        }
        InitializeBattle();
    }
    private void InitializeBattle()
    {
        CleanupBattle();

        Vector3 playerPos = playerSpawnPoint ? playerSpawnPoint.position : Vector3.left * 3f;
        Vector3 cpuPos = cpuSpawnPoint ? cpuSpawnPoint.position : Vector3.right * 3f;

        var battlePair = PikomonFactory.SpawnBattlePair(playerPos, cpuPos);
        playerController = battlePair.player;
        cpuController = battlePair.cpu;

        if (playerController != null && cpuController != null)
        {
            player_pikomon = playerController.GetPikomon();
            cpu_pikomon = cpuController.GetPikomon();

            if (playerHUD != null)
            {
                playerHUD.Initialize(playerController);
            }

            Debug.Log($"Battle initialized! Player: {player_pikomon.Name} vs CPU: {cpu_pikomon.Name}");
            ChangeGameState(IGameState.Initializing);
        }
        else
        {
            Debug.LogError("Failed to spawn Pikomons");
        }
    }
    private void CleanupBattle()
    {
        if (playerController != null)
        {
            Destroy(playerController.gameObject);
            playerController = null;
        }

        if (cpuController != null)
        {
            Destroy(cpuController.gameObject);
            cpuController = null;
        }

        player_pikomon = null;
        cpu_pikomon = null;
    }
    void Update()
    {
        if (player_pikomon == null || cpu_pikomon == null)
            return;

        if (playerHUD != null)
        {
            playerHUD.RefreshDisplay();
        }
        if (battleLogUI != null && battleLogUI.IsShowingLog())
            return;

        switch (CurrentGameState)
        {
            case IGameState.Initializing:
                Debug.Log("Game is initializing...");
                ChangeGameState(IGameState.Player_Turn);
                break;
            case IGameState.CPU_Turn:
                if (!cpuActionExecuted) 
                {
                    cpuActionExecuted = true;
                    RandomCPUAttack();
                }
                break;
            case IGameState.Player_Turn:
                break;
            case IGameState.Effect_Turn:
                ProcessEffects();
                break;
            case IGameState.Game_Over:
                ShowGameOverUI();
                break;
            case IGameState.Restarting:
                Debug.Log("Game is restarting...");
                ChangeGameState(IGameState.Initializing);
                break;
        }
    }


    public void ChangeGameState(IGameState newState)
    {
        CurrentGameState = newState;
        Debug.Log("Game State changed to: " + newState);

        if (newState == IGameState.Player_Turn)
        {
            cpuActionExecuted = false;
        }
    }

     private void ShowGameOverUI()
    {
        Debug.Log("Game Over");
        if (restartButton != null)
        {
            restartButton.gameObject.SetActive(true);
        }
        
        if (battleLogUI != null)
        {
            string winner = player_pikomon.Health <= 0 ? cpu_pikomon.Name : player_pikomon.Name;
            battleLogUI.ShowAttackLog(null, $"{winner} wins the battle!", null);
        }
    }
    private void OnRestartButtonClicked()
    {
        if (restartButton != null)
        {
            restartButton.gameObject.SetActive(false);
        }
        
        ChangeGameState(IGameState.Restarting);
        InitializeBattle();
    }
    [ContextMenu("Start New Battle")]
    public void StartNewBattle()
    {
        InitializeBattle();
    }
    public void RandomCPUAttack()
    {
        var randomPower = cpu_pikomon.Powers[Random.Range(0, cpu_pikomon.Powers.Count)];

        if (battleLogUI != null)
        {
            battleLogUI.ShowAttackLog(cpu_pikomon, randomPower.Name, () =>
            {
                randomPower.UsePower(cpu_pikomon, player_pikomon);
                ChangeGameState(IGameState.Effect_Turn);
            });
        }
        else
        {
            randomPower.UsePower(cpu_pikomon, player_pikomon);
            ChangeGameState(IGameState.Effect_Turn);
        }
    }
    public void PlayerAttack(Power power)
    {
        if (battleLogUI != null)
        {
            battleLogUI.ShowAttackLog(player_pikomon, power.Name, () =>
            {
                power.UsePower(player_pikomon, cpu_pikomon);
                ChangeGameState(IGameState.CPU_Turn);
            });
        }
        else
        {
            power.UsePower(player_pikomon, cpu_pikomon);
            ChangeGameState(IGameState.CPU_Turn);
        }
    }
    private void ProcessEffects()
    {
        cpu_pikomon.ProcessEffects();
        player_pikomon.ProcessEffects();
        
        if (player_pikomon.Health <= 0 || cpu_pikomon.Health <= 0)
        {
            Debug.Log("A Pikomon has fainted!");
            Debug.Log($"Player Pikomon Health: {player_pikomon.Health}, CPU Pikomon Health: {cpu_pikomon.Health}");
            
            if (player_pikomon.Health <= 0)
            {
                Debug.Log("Player Pikomon has fainted!");
            }
            else
            {
                Debug.Log("CPU Pikomon has fainted!");
            }
            ChangeGameState(IGameState.Game_Over);
        }
        else
        {
            ChangeGameState(IGameState.Player_Turn);
        }
    }
}
