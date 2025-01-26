using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    public GameObject canvasCredits;
    public GameObject canvasPause;
    public GameObject canvasOptions;
    public bool isGamePaused = false;


    //Main menu//

    //play
    public void PlayGame()
    {
        SceneManager.LoadScene("FirstLevel");
    }

    //credits
    public void ShowCredits()
    {
        canvasCredits.gameObject.SetActive(true);

    }

    public void CloseCredits()
    {
        canvasCredits.gameObject.SetActive(false);

    }
    //Options

    public void ShowOptions()
    {
        canvasOptions.gameObject.SetActive(true);

    }

    public void CloseOptions()
    {
        canvasOptions.gameObject.SetActive(false);

    }
    //exit
    public void doExitGame()
    {
        Application.Quit();
    }

    //Pause menu//
    public void PauseGame()
    {
        canvasPause.gameObject.SetActive(true);
        Time.timeScale = 0;
        isGamePaused = true;
        //add code to hit esc for pause
    }

    public void ContinueGame()
    {
        canvasPause.gameObject.SetActive(false);
        Time.timeScale = 1;
        isGamePaused = false;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                ContinueGame();
                Debug.Log("Game should NOT be paused rn");
            }
            else
            {
                PauseGame();
                Debug.Log("Game should be paused rn");
            }
        }
    }

    public void ExitGameplay()
    {
        SceneManager.LoadScene("Main Menu");
    }
}



