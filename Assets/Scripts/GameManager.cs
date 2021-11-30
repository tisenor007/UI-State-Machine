using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public enum GameState
    {
        MainMenu,
        GamePlay,
        Paused,
        Win,
        Lose
    }
    [HideInInspector]
    public GameState gameState;
    public static GameManager gameManager;
    public GameObject UIManager;
    public GameObject buttonManager;
    private UIManager UIManagerScript;
    private Scene currentScene;
    private string sceneName;

    void Awake()
    {
        //Singleton
        if (gameManager == null)
        {
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(UIManager);
            DontDestroyOnLoad(buttonManager);
            gameManager = this;
        }
        else if (gameManager != this)
        {
            Destroy(gameObject);
            Destroy(UIManager);
            Destroy(buttonManager);
        }
    }
    void Start()
    {
        UIManagerScript = UIManager.GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;

        if (gameState != GameState.Paused && gameState != GameState.Win && gameState != GameState.Lose)
        {
            Time.timeScale = 1;
        }

        switch (gameState)
        {
            case GameState.MainMenu:
                if (sceneName != "Title") { SceneManager.LoadScene("Title", LoadSceneMode.Single); }
                UIManagerScript.ShowMainMenu();
                break;
            case GameState.GamePlay:
                if (sceneName != "GamePlay") { SceneManager.LoadScene("GamePlay", LoadSceneMode.Single); }
                UIManagerScript.ShowGameplayUI();
                CheckToPause();
                break;
            case GameState.Paused:
                if (sceneName != "GamePlay") { SceneManager.LoadScene("GamePlay", LoadSceneMode.Single); }
                UIManagerScript.ShowPauseMenu();
                Time.timeScale = 0;
                break;
            case GameState.Win:
                if (sceneName != "GamePlay") { SceneManager.LoadScene("GamePlay", LoadSceneMode.Single); }
                UIManagerScript.ShowWinScreen();
                Time.timeScale = 0;
                break;
            case GameState.Lose:
                if (sceneName != "GamePlay") { SceneManager.LoadScene("GamePlay", LoadSceneMode.Single); }
                UIManagerScript.ShowLoseScreen();
                Time.timeScale = 0;
                break;
        }
    }

    public void CheckToPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameState = GameState.Paused;
        }
    }
   
}
