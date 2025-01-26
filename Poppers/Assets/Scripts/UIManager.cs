using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    public GameObject CanvasCredits;
    public GameObject CanvasPause;
    public AudioSource clickSFX;
    public bool isGamePaused = false;


    //Main menu//
    public void PlayGame()
    {
        clickSFX.Play();
        SceneManager.LoadScene("FirstLevel");
    }

    public void ShowCredits()
    {
        clickSFX.Play(); 
        CanvasCredits.gameObject.SetActive(true);

    }

    public void CloseCredits()
    {
        clickSFX.Play(); 
        CanvasCredits.gameObject.SetActive(false);

    }

    public void doExitGame()
    {
        clickSFX.Play(); 
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
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
    }
}



