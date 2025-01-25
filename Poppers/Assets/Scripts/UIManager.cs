using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    public GameObject CanvasCredits;



    public void PlayGame()
    {
        SceneManager.LoadScene("InGameScene");
    }

    public void ShowCredits()
    {
        CanvasCredits.gameObject.SetActive(true);
        //gameObject GetComponent <Canvas>("CanvasCredits").enabled = true;
    }

    public void CloseCredits()
    {
        CanvasCredits.gameObject.SetActive(false);
        //gameObject GetComponent <Canvas>("CanvasCredits").enabled = true;
    }

    public void doExitGame()
    {
        Application.Quit();
    }




}
