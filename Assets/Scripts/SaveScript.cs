using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveScript : MonoBehaviour
{
    public static float P1Health = 1.0f;
    public static float P2Health = 1.0f;
    public static float P1Timer = 2.0f;
    public static float P2Timer = 2.0f;
    public static bool TimeOut = false;
    public static bool Player1Mode = true;
    public static int P1Wins = 0;
    public static int P2Wins = 0;
    public static int round = 0;
    public static float maxHealth = 1.0f;
    [SerializeField] private GameObject win1,win2,tie;
    [SerializeField] private TimerScript time;

    // Start is called before the first frame update
    void Start()
    {
        P1Health = 1.0f;
        P2Health = 1.0f;

        win1.SetActive(false);
        win2.SetActive(false);
        tie.SetActive(false);
        TimeOut = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(time.LevelTime <= 0.5){
            TimeOut = true;
        }

        // if(Input.GetKeyDown(KeyCode.G)) {
        //     P1Health -= .05f;
        // }
        
        // if(Input.GetKeyDown(KeyCode.H)) {
        //     P2Health -= .05f;
        // }

        if(P1Health <= 0.0f || (TimeOut && P1Health < P2Health)) {
            win2.SetActive(true);
            win1.SetActive(false);
            tie.SetActive(false);
            TimeOut = true;
        }
        else if (P2Health <= 0.0f || (TimeOut && P2Health < P1Health))  
        {
            win1.SetActive(true);
            win2.SetActive(false);
            tie.SetActive(false);
            TimeOut = true;
        }
        else if(TimeOut)
        {
            win1.SetActive(false);
            win2.SetActive(false);
            tie.SetActive(true);
            TimeOut = true;
        }

    }


}
