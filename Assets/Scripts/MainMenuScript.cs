using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenuScript : MonoBehaviour
{
    // [SerializeField] private GameObject menu;
    [SerializeField] private GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(button);
    }

    void Update()
    {
        // EventSystem.current.SetSelectedGameObject(button);
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
