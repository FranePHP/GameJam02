using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float health = 100f;
    public bool isSucking = false;

    private void Start()
    {
        health = 100f;
        isSucking = false;
    }

    private void Update()
    {
        if (!isSucking)
        {
            health -= Time.deltaTime;
        }
    }
}
