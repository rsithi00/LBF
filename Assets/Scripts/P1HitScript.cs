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
    void OnCollisionEnter2D(Collision2D col)
    {
        SaveScript.P2Health -= 0.05f;
    }



}
