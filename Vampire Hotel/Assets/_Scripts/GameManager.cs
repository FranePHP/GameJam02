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
    bool gameOver;

    [Header("Score")]
    long score = 0;
    uint level = 0;

    [Header("Enemy Spawner")]
    [SerializeField] float spawnTime = 5f;
    /*[SerializeField] GameObject[,] enemies; // [room number][number of enemy in the room]
    [SerializeField] GameObject[] enemiesRoom1; // zna tko je u kojoj prostoriji ali ne je li aktivan
    [SerializeField] GameObject[] enemiesRoom2;
    [SerializeField] GameObject[] enemiesRoom3;
    [SerializeField] GameObject[] enemiesRoom4;
    [SerializeField] GameObject[] enemiesRoom5;
    [SerializeField] GameObject[] enemiesRoom6;
    [SerializeField] GameObject[] enemiesRoom7;
    [SerializeField] GameObject[] enemiesRoom8;
    [SerializeField] Dictionary<int, GameObject> enemiesD = new Dictionary<int, GameObject>();
    //[SerializeField] G*/

    private void Start()
    {
        health = 100f;
        isSucking = false;
        score = 0;

        
        /*for (int i = 0; i < 8; i++)
        {
            
            for (int j = 0; j < enemiesRoom1.Length; j++)
            {
                enemies[i, j] = enemiesRoom1[j];
            }
        }*/

        StartCoroutine(SpawnEnemy());
    }

    private void Update()
    {
        if (!isSucking)
        {
            health -= Time.deltaTime;
            UpdateHealthSlider();
        }

        Debug.Log("Player is currently in room number " + pm.room + " (Hallway is 0)");
    }

    IEnumerator SpawnEnemy()
    {
        while (!gameOver)
        {
            yield return new WaitForSeconds(spawnTime);

            for (int rooms = 1; rooms <= 8; rooms++) // potrebna iteracija da se zna tko je trenutno aktivan
            {
                
            }

            /*bool spawned = false;

            while (!spawned)
            {
                int randEnemy = Random.Range(0, enemies.Length);
                float dist = Vector3.Distance(enemies[randEnemy].transform.position, player.position);

                if (dist > 10)
                {
                    enemies[randEnemy].SetActive(true);
                    spawned = true;
                }
            }*/
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


