
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static event Action<GameState> OnGameStateChanged;
    public static GameManager instance { get; private set; }

    public GameState State { get; private set; }
    public AudioSource audioSource;
    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }
    }

    void Start()
    {
        ChangeState(GameState.Menu);
    }

    void Update()
    {
        HandleDecide();
    }

    public void ChangeState(GameState newstate)
    {
        State = newstate;

        switch (newstate)
        {
            case GameState.Menu:

                Debug.Log("Menu State");
                break;
            case GameState.Start:
                Debug.Log("Start state");
                break;
            case GameState.Win:
                //stop game// show UI MENU

                SceneManager.LoadScene(2);
                Debug.Log("wiiiiiiiiiiiiiiiiiiin");
                break;
            case GameState.Lose:
                //STOP GAME // SHOW UI MENU 
                SceneManager.LoadScene(3);
                Debug.Log("Looooooooose");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newstate), newstate, null);
        }

        OnGameStateChanged?.Invoke(newstate);
    }

    public void HandleDecide()
    {
        if (ScoreManager.instance.score == 10)
        {
            ChangeState(GameState.Win);
        }


        if (ScoreManager.instance.health <= 0)
        {
            ChangeState(GameState.Lose);
        }
    }
    public enum GameState
    {
        Menu,
        Start,
        Win,
        Lose
    }
}
