using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnePlayerMode()
    {
        SaveScript.Player1Mode = true;
        SceneManager.LoadScene(1);
    }

    public void TwoPlayerMode()
    {
        SaveScript.Player1Mode = false;
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    
    }
}
