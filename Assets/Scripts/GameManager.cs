
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenu, losePanel, winPanel, StartPanel, playButton;
    public static bool played = false;
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
        SoundManager.Instance.playMusic();
        ChangeState(GameState.Start);
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
                Time.timeScale = 1f;
                break;
            case GameState.Win:
                //stop game// show UI MENU
                Time.timeScale = 0.0f;
                SceneManager.LoadScene(2);
                //winPanel.SetActive(true);
                Debug.Log("wiiiiiiiiiiiiiiiiiiin");
                break;
            case GameState.Lose:
                //STOP GAME // SHOW UI MENU 
                //SceneManager.LoadScene(0);
                losePanel.SetActive(true);
                Time.timeScale = 0.0f;
                Debug.Log("Looooooooose");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newstate), newstate, null);
        }

        OnGameStateChanged?.Invoke(newstate);
    }

    void Win()
    {
        ChangeState(GameState.Win);
    }
    public void HandleDecide()
    {
        if (ScoreManager.instance.win)
        {

            SoundManager.Instance.playWinSound();
            
            Invoke("Win", 6);
           

        }

        if (ScoreManager.instance.health <= 0)
        {
            ChangeState(GameState.Lose);
            if (!played)
            {
                SoundManager.Instance.playdeadSound();
                played = true; // Plays sound only once
            }
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
