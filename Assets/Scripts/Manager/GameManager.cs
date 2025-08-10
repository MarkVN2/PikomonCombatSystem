using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public IGameState CurrentGameState { get; private set; }

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
        ChangeGameState(IGameState.MainMenu);
    }

    public void ChangeGameState(IGameState newState)
    {
        CurrentGameState = newState;
        Debug.Log("Game State changed to: " + newState);
    }
}
