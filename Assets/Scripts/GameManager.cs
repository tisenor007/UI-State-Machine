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
        OptionsMenu,
        GamePlay,
        Paused,
        Win,
        Lose
    }
    [HideInInspector]
    public GameState gameState;
    public static GameManager gameManager;
    public AudioSource music;
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
        gameState = GameState.MainMenu;
    }

    // Update is called once per frame
    void Update()
    {
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        AudioListener.volume = PlayerPrefs.GetFloat("volume");

        if (gameState != GameState.Paused && gameState != GameState.Win && gameState != GameState.Lose && gameState != GameState.OptionsMenu)
        {
            Time.timeScale = 1;
        }
        if (music.isPlaying == false)
        {
            music.Play(0);
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
                CheckInput();
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
            case GameState.OptionsMenu:
                if (sceneName != "Title") { SceneManager.LoadScene("Title", LoadSceneMode.Single); }
                UIManagerScript.ShowOptionsMenu();
                Time.timeScale = 0;
                break;
        }
    }

    public void AdjustVolume(float value)
    {
        PlayerPrefs.SetFloat("volume", value);
    }

    public void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            gameState = GameState.Paused;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            gameState = GameState.Win;
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            gameState = GameState.Lose;
        }
    }
   
}
