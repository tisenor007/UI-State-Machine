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
    public Canvas inventoryUI;
    public Canvas creditsUI;

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
        creditsUI.enabled = false;
        mainMenu.enabled = true;
        pauseMenu.enabled = false;
        gameplayUI.enabled = false;
        winScreen.enabled = false;
        loseScreen.enabled = false;
        optionsMenu.enabled = false;
        inventoryUI.enabled = false;
    }

    public void ShowPauseMenu()
    {
        creditsUI.enabled = false;
        mainMenu.enabled = false;
        pauseMenu.enabled = true;
        gameplayUI.enabled = false;
        winScreen.enabled = false;
        loseScreen.enabled = false;
        optionsMenu.enabled = false;
        inventoryUI.enabled = false;
    }

    public void ShowGameplayUI()
    {
        creditsUI.enabled = false;
        mainMenu.enabled = false;
        pauseMenu.enabled = false;
        gameplayUI.enabled = true;
        winScreen.enabled = false;
        loseScreen.enabled = false;
        optionsMenu.enabled = false;
        inventoryUI.enabled = false;
    }

    public void ShowWinScreen()
    {
        creditsUI.enabled = false;
        mainMenu.enabled = false;
        pauseMenu.enabled = false;
        gameplayUI.enabled = false;
        winScreen.enabled = true;
        loseScreen.enabled = false;
        optionsMenu.enabled = false;
        inventoryUI.enabled = false;
    }

    public void ShowLoseScreen()
    {
        creditsUI.enabled = false;
        mainMenu.enabled = false;
        pauseMenu.enabled = false;
        gameplayUI.enabled = false;
        winScreen.enabled = false;
        loseScreen.enabled = true;
        optionsMenu.enabled = false;
        inventoryUI.enabled = false;
    }

    public void ShowOptionsMenu()
    {
        creditsUI.enabled = false;
        mainMenu.enabled = false;
        pauseMenu.enabled = false;
        gameplayUI.enabled = false;
        winScreen.enabled = false;
        loseScreen.enabled = false;
        optionsMenu.enabled = true;
        inventoryUI.enabled = false;
    }

    public void ShowInventory()
    {
        creditsUI.enabled = false;
        mainMenu.enabled = false;
        pauseMenu.enabled = false;
        gameplayUI.enabled = false;
        winScreen.enabled = false;
        loseScreen.enabled = false;
        optionsMenu.enabled = false;
        inventoryUI.enabled = true;
    }

    public void ShowCreditsScreen()
    {
        creditsUI.enabled = true;
        mainMenu.enabled = false;
        pauseMenu.enabled = false;
        gameplayUI.enabled = false;
        winScreen.enabled = false;
        loseScreen.enabled = false;
        optionsMenu.enabled = false;
        inventoryUI.enabled = false;
    }
}
