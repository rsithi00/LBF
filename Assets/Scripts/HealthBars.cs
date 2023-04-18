using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBars : MonoBehaviour
{
    public UnityEngine.UI.Image P1Life;
    public UnityEngine.UI.Image P2Life;
    public float lerpSpeed;

    public 
    // Start is called before the first frame update
    void Start()
    {
         lerpSpeed = .0001f;
    }

    // Update is called once per frame
    void Update()
    {

        P1Life.fillAmount = SaveScript.P1Health;
        P2Life.fillAmount = SaveScript.P2Health;

        HealthBarFiller();
        ColorChanger();
    

    void HealthBarFiller()
    {
        P1Life.fillAmount = Mathf.Lerp(P1Life.fillAmount, SaveScript.P1Health/SaveScript.maxHealth, lerpSpeed);
        P2Life.fillAmount = Mathf.Lerp(P2Life.fillAmount, SaveScript.P1Health/SaveScript.maxHealth, lerpSpeed);
    }

    void ColorChanger()
    {
        Color healthColor1 = Color.Lerp(Color.red, Color.green, (SaveScript.P1Health/SaveScript.maxHealth));   
        P1Life.color = healthColor1;

        Color healthColor2 = Color.Lerp(Color.red, Color.green, (SaveScript.P2Health/SaveScript.maxHealth));   
        P2Life.color = healthColor2;
    }
        
    }
}
