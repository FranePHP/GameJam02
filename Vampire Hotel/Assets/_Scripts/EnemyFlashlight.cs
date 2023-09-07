using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlashlight : MonoBehaviour
{
    GameManager gm;
    PlayerMovement pm;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        pm = FindObjectOfType<PlayerMovement>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gm.health -= Time.deltaTime*2;
            pm.canSuck = false;
            Debug.Log("detected");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pm.canSuck = true;
            Debug.Log("escaped");
        }
    }
}
