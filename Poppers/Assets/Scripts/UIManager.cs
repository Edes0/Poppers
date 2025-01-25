using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    public GameObject CanvasCredits;
    public GameObject CanvasPause;


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
        //add code to hit esc for pause
    }

    public void UnpauseGame()
    {
        CanvasPause.gameObject.SetActive(false);

    }

    public void ExitGameplay()
    {
        SceneManager.LoadScene("Main Menu");
    }


}
