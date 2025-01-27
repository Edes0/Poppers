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
    public AudioManager audioManager;

    //Main menu//

    //play
    public void PlayGame()
    {
        
        audioManager.BubblePopSound();
        SceneManager.LoadScene("FirstLevel");
    }

    //credits
    public void ShowCredits()
    {
        audioManager.BubblePopSound();
        canvasCredits.gameObject.SetActive(true);

    }

    public void CloseCredits()
    {
        audioManager.BubblePopSound();
        canvasCredits.gameObject.SetActive(false);

    }
    //Options

    public void ShowOptions()
    {
        audioManager.BubblePopSound();
        canvasOptions.gameObject.SetActive(true);

    }

    public void CloseOptions()
    {
        audioManager.BubblePopSound();
        canvasOptions.gameObject.SetActive(false);

    }
    //exit
    public void doExitGame()
    {
        audioManager.BubblePopSound();
        Application.Quit();
    }

    //Pause menu//
    public void PauseGame()
    {
        audioManager.BubblePopSound();             
        canvasPause.gameObject.SetActive(true);
        Time.timeScale = 0;
        isGamePaused = true;
        //add code to hit esc for pause
    }

    public void ContinueGame()
    {
        audioManager.BubblePopSound();
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
        
        Time.timeScale = 1;
        audioManager.BubblePopSound();
        SceneManager.LoadScene("Main Menu");
    }
}



