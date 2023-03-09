using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using static GameManager;

public class MenuManager : MonoBehaviour
{

    [SerializeField]
    private GameObject pauseMenu, losePanel, winPanel, StartPanel, playButton;


    //[SerializeField]
    //private TextMeshProUGUI stateText;

    //void Awake()
    //{
    //    GameManager.OnGameStateChanged += GameManagerOnGameStateChanged;
    //}

    //void OnDestroy()
    //{
    //    GameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;

    //}
    //private void GameManagerOnGameStateChanged(GameState state)
    //{
    //    playButton.SetActive(state == GameState.Start);
    //}
    // Start is called before the first frame update


    public void StartGame()
    {
        SceneManager.LoadScene(1);
        //GameManager.Instance.ChangeState(GameState.Start);

    }

    public void Restart()
    {
        
        SceneManager.LoadScene(0);
        //GameManager.Instance.ChangeState(GameState.Win);
        

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            Pause();
        }
         
    }


    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void Resume()
    {

        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;

    }

    public void Home(int sceneID)
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(sceneID);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
