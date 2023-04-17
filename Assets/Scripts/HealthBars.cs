using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBars : MonoBehaviour
{
    public UnityEngine.UI.Image P1Life;
    public UnityEngine.UI.Image P2Life;

    public 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        P1Life.fillAmount = SaveScript.P1Health;
        P2Life.fillAmount = SaveScript.P2Health;
        
    }
}
