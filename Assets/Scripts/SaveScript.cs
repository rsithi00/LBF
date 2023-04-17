using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    

    // Start is called before the first frame update
    void Start()
    {
        P1Health = 1.0f;
        P2Health = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G)) {
            P1Health -= .05f;
        }
        
        if(Input.GetKeyDown(KeyCode.H)) {
            P2Health -= .05f;
        }
    }
}
