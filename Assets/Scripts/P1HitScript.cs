using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1HitScript : MonoBehaviour
{
    // [SerializeField] private GameObject colOpp;
    void Start()
    {

    }
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        SaveScript.P2Health -= 0.02f;
        // Debug.Log("P1 Hit Success!");
    }



}
