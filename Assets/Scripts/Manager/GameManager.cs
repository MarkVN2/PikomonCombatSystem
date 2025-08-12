using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public IGameState CurrentGameState { get; private set; }
    public PikoController player1;
    public PikoController cpu;
    private Pikomon cpu_pikomon;
    private Pikomon player_pikomon;
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
                cpu_pikomon = cpu.GetPikomon();
                player_pikomon = player1.GetPikomon();
    }
    void Update()
    {
        switch (CurrentGameState)
        {
            case IGameState.Initializing:
                Debug.Log("Game is initializing...");
                ChangeGameState(IGameState.Player_Turn);
                break;
            case IGameState.CPU_Turn:

                break;
            case IGameState.Player_Turn:

                break;
            case IGameState.Effect_Turn:
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
                ChangeGameState(IGameState.Player_Turn);

                break;
            case IGameState.Game_Over:
                Debug.Log("Game Over");
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
    }
}
