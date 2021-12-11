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
        Inventory,
        Win,
        Credits,
        Lose
    }
    [HideInInspector]
    public GameState gameState;
    public static GameManager gameManager;
    public AudioSource music;
    public GameObject UIManager;
    public GameObject buttonManager;
    private UIManager UIManagerScript;

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
        AudioListener.volume = PlayerPrefs.GetFloat("volume");

        if (gameState != GameState.Paused && gameState != GameState.Win && gameState != GameState.Lose && gameState != GameState.OptionsMenu && gameState != GameState.Inventory)
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
                if (SceneManager.GetActiveScene().name != "Title") { SceneManager.LoadScene("Title", LoadSceneMode.Single); }
                UIManagerScript.ShowMainMenu();
                break;
            case GameState.GamePlay:
                if (SceneManager.GetActiveScene().name != "GamePlay") { SceneManager.LoadScene("GamePlay", LoadSceneMode.Single); }
                UIManagerScript.ShowGameplayUI();
                CheckInput();
                break;
            case GameState.Paused:
                if (SceneManager.GetActiveScene().name != "GamePlay") { SceneManager.LoadScene("GamePlay", LoadSceneMode.Single); }
                UIManagerScript.ShowPauseMenu();
                Time.timeScale = 0;
                break;
            case GameState.Win:
                if (SceneManager.GetActiveScene().name != "GameOver") { SceneManager.LoadScene("GameOver", LoadSceneMode.Single); }
                UIManagerScript.ShowWinScreen();
                Time.timeScale = 0;
                break;
            case GameState.Lose:
                if (SceneManager.GetActiveScene().name != "GameOver") { SceneManager.LoadScene("GameOver", LoadSceneMode.Single); }
                UIManagerScript.ShowLoseScreen();
                Time.timeScale = 0;
                break;
            case GameState.OptionsMenu:
                if (SceneManager.GetActiveScene().name != "Title") { SceneManager.LoadScene("Title", LoadSceneMode.Single); }
                UIManagerScript.ShowOptionsMenu();
                Time.timeScale = 0;
                break;
            case GameState.Inventory:
                if (SceneManager.GetActiveScene().name != "GamePlay") { SceneManager.LoadScene("GamePlay", LoadSceneMode.Single); }
                UIManagerScript.ShowInventory();
                Time.timeScale = 0;
                break;
            case GameState.Credits:
                if (SceneManager.GetActiveScene().name != "Title") { SceneManager.LoadScene("Title", LoadSceneMode.Single); }
                UIManagerScript.ShowCreditsScreen();
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
        else if (Input.GetKeyDown(KeyCode.I))
        {
            gameState = GameState.Inventory;
        }
    }
   
}
