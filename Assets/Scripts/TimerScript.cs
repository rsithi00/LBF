using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

/*Comment*/

public class TimerScript : MonoBehaviour
{

    public TextMeshProUGUI countdownTimer;
    public float LevelTime = 99;

    private bool timeStop;

    // Start is called before the first frame update
    void Start()
    {
        timeStop = false;    
    }

    // Update is called once per frame
    void Update()
    {

        if(SaveScript.P1Health <=0 || SaveScript.P2Health <=0)
        {
            timeStop = true;
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

 
        if(LevelTime > 0 && !timeStop)
        {
            LevelTime -= 1 * Time.deltaTime;
        }
        

        countdownTimer.text = Mathf.Round(LevelTime).ToString();

        if(timeStop == true)
        {
            
            StartCoroutine(Reload());
        }

        IEnumerator Reload()
        {
            yield return new WaitForSeconds(3f);

            SceneManager.LoadScene(0);
        } 
        
    }

    
}
