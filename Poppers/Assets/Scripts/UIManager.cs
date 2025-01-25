using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    public GameObject CanvasCredits;
    public GameObject CanvasPause;
    public bool isGamePaused = false;


    //Main menu//
    public void PlayGame()
    {
        SceneManager.LoadScene("InGameScene");
    }

    public void ShowCredits()
    {
        CanvasCredits.gameObject.SetActive(true);

    }

    public void CloseCredits()
    {
        CanvasCredits.gameObject.SetActive(false);

    }

    public void doExitGame()
    {
        Application.Quit();
    }

    //Pause menu//
    public void PauseGame()
    {
        CanvasPause.gameObject.SetActive(true);
        Time.timeScale = 0;
        isGamePaused = true;
        //add code to hit esc for pause
    }

    public void ContinueGame()
    {
        CanvasPause.gameObject.SetActive(false);
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



