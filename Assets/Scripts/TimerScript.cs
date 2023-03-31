using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{

    public TextMeshProUGUI countdownTimer;
    public float LevelTime = 99;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
        if(LevelTime > 0)
        {
            LevelTime -= 1 * Time.deltaTime;
        }

        countdownTimer.text = Mathf.Round(LevelTime).ToString();
    }

    
}
