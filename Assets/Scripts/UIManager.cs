using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Canvas mainMenu;
    public Canvas pauseMenu;
    public Canvas gameplayUI;
    public Canvas winScreen;
    public Canvas loseScreen;
    public Canvas optionsMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowMainMenu()
    {
        mainMenu.enabled = true;
        pauseMenu.enabled = false;
        gameplayUI.enabled = false;
        winScreen.enabled = false;
        loseScreen.enabled = false;
        optionsMenu.enabled = false;
    }

    public void ShowPauseMenu()
    {
        mainMenu.enabled = false;
        pauseMenu.enabled = true;
        gameplayUI.enabled = false;
        winScreen.enabled = false;
        loseScreen.enabled = false;
        optionsMenu.enabled = false;
    }

    public void ShowGameplayUI()
    {
        mainMenu.enabled = false;
        pauseMenu.enabled = false;
        gameplayUI.enabled = true;
        winScreen.enabled = false;
        loseScreen.enabled = false;
        optionsMenu.enabled = false;
    }

    public void ShowWinScreen()
    {
        mainMenu.enabled = false;
        pauseMenu.enabled = false;
        gameplayUI.enabled = false;
        winScreen.enabled = true;
        loseScreen.enabled = false;
        optionsMenu.enabled = false;
    }

    public void ShowLoseScreen()
    {
        mainMenu.enabled = false;
        pauseMenu.enabled = false;
        gameplayUI.enabled = false;
        winScreen.enabled = false;
        loseScreen.enabled = true;
        optionsMenu.enabled = false;
    }

    public void ShowOptionsMenu()
    {
        mainMenu.enabled = false;
        pauseMenu.enabled = false;
        gameplayUI.enabled = false;
        winScreen.enabled = false;
        loseScreen.enabled = false;
        optionsMenu.enabled = true;
    }
}
