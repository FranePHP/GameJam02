using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] EnemyManager manager;
    [SerializeField] Light flashlight;
    PlayerMovement pm;
    GameManager gm;
    public float rotSpeed = 15f;
    float hp = 1f;
    float flashlightRangeMax = 8;
    bool detected = false;

    private void Start()
    {
        detected = false;
        flashlightRangeMax = 8;
        transform.Rotate(0, Random.Range(1, 11) * 36f, 0);
        gm = FindObjectOfType<GameManager>();
        pm = FindObjectOfType<PlayerMovement>();
    }

    private void Update()
    {
        if (!detected)
        {
            transform.Rotate(0, rotSpeed * Time.deltaTime, 0);
        }

        // "Animacija" pojavljivanja neprijatelja scale-anjem od 0 do 1
        if (transform.localScale.x < 1)
        {
            transform.localScale += Vector3.one * Time.deltaTime;

            if (transform.localScale.x > 1)
            {
                transform.localScale = Vector3.one;
            }
        }

        if (flashlight.range <= flashlightRangeMax)
        {
            flashlight.range += 8*Time.deltaTime;

            if (flashlight.range > flashlightRangeMax)
            {
                flashlight.range = flashlightRangeMax;
            }
        }
    }

    private void OnEnable()
    {
        hp = 1f;
        transform.localScale = Vector3.zero;
        transform.Rotate(0, Random.Range(1, 11) * 36f, 0);
        flashlight.range = 0;
        detected = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            detected = true;

            if (pm.canSuck)
            {
                hp -= Time.deltaTime;

                if (hp <= 0)
                {
                    manager.StartSpawnCoroutine();
                    gm.AddScore(10);
                    gameObject.SetActive(false);
                }
            }
        }
        else
        {
            detected = false;
        }
    }
}
