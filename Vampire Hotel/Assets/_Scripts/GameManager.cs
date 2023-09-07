using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Smanjiti prije builda")]
    [SerializeField] float levelupScale = 1f; // postotak
    
    [Header("Player")]
    public float health = 60f;
    public bool isSucking = false;
    public PlayAnimation playerAnimation;
    [SerializeField] Transform player;
    [SerializeField] PlayerMovement pm;
    public bool gameOver;
    public bool jesam;

    [Header("Score")]
    public int score = 0;
    public int level = 0;

    [Header("Enemy Spawner")]
    //[SerializeField] float spawnTime = 5f;
    public int enemyLimitGlobal = 5; // koliko odjednom smije biti enemyja (sve skupa)
    public int enemyLimitLocal = 1; // koliko odjednom u blizini (otprilike po prostoriji) smije biti neprijatelja
    [SerializeField] EnemyManager[] enemies; // koristeno samo za referenciranje enemymanagera prilikom levelupa 

    [Header("UI")]
    //[SerializeField] Slider healthSlider;
    [SerializeField] Image healthBarBackground;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI levelText;

    private void Start()
    {
        health = 60f;
        score = 0;
        level = 0;
        isSucking = false;
        score = 0;
        gameOver = false;
        UpdateHealthSlider();
        UpdateScoreText();
        UpdateLevelText();
    }

    private void Update()
    {
        if (!isSucking)
        {
            health -= Time.deltaTime;
            UpdateHealthSlider();

            if (health <= 0)
            {
                gameOver = true;
                Debug.Log("Game Over");
            }
        }

        if (gameOver && !jesam)
        {
            GameOver();
            jesam = true;
        }
    }
    
    void UpdateHealthSlider()
    {
        if (healthBarBackground != null)
        {
            if (health <= 100f)
            {
                healthBarBackground.fillAmount = health / 100f;
                healthBarBackground.color = Color.red;
            }
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }
    void UpdateLevelText()
    {
        levelText.text = level.ToString();
    }

    void GameOver()
    {
        playerAnimation.Fall_Flat();
    }

    public void AddScore(float amount)
    {
        health += 10;
        UpdateHealthSlider();
        score += 10;
        UpdateScoreText();

        if (score >= (((level + 1)*(level + 1)) * 100 * levelupScale)) // formula za levelupanje: tijekom levela 0 -> 100; tijekom levela 1 -> 400; tijekom levela 2 -> 900
        {
            level++;
            UpdateLevelText();

            for (int i = 0; i < enemies.Length; i++) // updateamo odmah difficulty
            {
                enemies[i].ManageDifficulty();
            }

            Debug.Log("TODO levelup ui popup");
        }
    }
}


