using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] EnemyManager manager;
    [SerializeField] Light flashlight;
    public float rotSpeed = 15f;
    float hp = 1f;
    float flashlightRangeMax = 8;

    private void Start()
    {
        flashlightRangeMax = 8;
    }

    private void Update()
    {
        transform.Rotate(0, rotSpeed * Time.deltaTime, 0);

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
        flashlight.range = 0;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hp -= Time.deltaTime;

            if (hp <= 0)
            {
                manager.StartSpawnCoroutine();
                gameObject.SetActive(false);
            }
        }
    }
}
