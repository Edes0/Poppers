using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagerClass : MonoBehaviour
{
   
    [SerializeField] private string InGameScene = "InGameScene";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {

    }
    [ContextMenu("RestartGame")]
    public void RestartGame()
    {
        SceneManager.LoadScene(InGameScene);
    }

}
