using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Player")]
    public float health = 100f;
    public bool isSucking = false;
    [SerializeField] Slider healthSlider;
    [SerializeField] Transform player;
    [SerializeField] PlayerMovement pm;
    public bool gameOver;

    [Header("Score")]
    public int score = 0;
    public int level = 0;

    [Header("Enemy Spawner")]
    //[SerializeField] float spawnTime = 5f;
    public int enemyLimitGlobal = 5; // koliko odjednom smije biti enemyja (sve skupa)
    public int enemyLimitLocal = 1; // koliko odjednom u blizini (otprilike po prostoriji) smije biti neprijatelja

    private void Start()
    {
        health = 100f;
        isSucking = false;
        score = 0;
        gameOver = false;
    }

    private void Update()
    {
        if (!isSucking)
        {
            health -= Time.deltaTime;
            UpdateHealthSlider();
        }

        //Debug.Log("Player is currently in room number " + pm.room + " (Hallway is 0)");
    }
    
    void UpdateHealthSlider()
    {
        if (healthSlider != null)
        {
            healthSlider.value = health; 
        }
    }

    void GameOver()
    {
        StopAllCoroutines();
    }
}


