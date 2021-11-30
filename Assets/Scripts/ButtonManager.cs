using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject gameManager;
    private GameManager gameManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = gameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToMainMenu()
    {
        gameManagerScript.gameState = GameManager.GameState.MainMenu;
    }

    public void GoToGamePlay()
    {
        gameManagerScript.gameState = GameManager.GameState.GamePlay;
    }

    public void PauseGame()
    {
        gameManagerScript.gameState = GameManager.GameState.Paused;
    }

    public void GoToWinScreen()
    {
        gameManagerScript.gameState = GameManager.GameState.Win;
    }

    public void GoToLoseScreen()
    {
        gameManagerScript.gameState = GameManager.GameState.Lose;
    }

    public void GoToOptionsMenu()
    {
        gameManagerScript.gameState = GameManager.GameState.OptionsMenu;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
