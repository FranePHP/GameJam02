using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float health = 100f;
    public bool isSucking = false;
    public Slider healthSlider; 

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
            UpdateHealthSlider(); 
        }
    }

    
    void UpdateHealthSlider()
    {
        if (healthSlider != null)
        {
            healthSlider.value = health; 
        }
    }
}


