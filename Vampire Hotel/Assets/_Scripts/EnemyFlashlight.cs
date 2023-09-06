using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlashlight : MonoBehaviour
{
    GameManager gm;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gm.health -= Time.deltaTime*2;
            Debug.Log("detected");
        }
    }
}
