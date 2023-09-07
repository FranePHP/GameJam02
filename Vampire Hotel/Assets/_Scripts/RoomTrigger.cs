using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    [SerializeField] int roomNum = 0;
    int enemyCount = 0;

    private void OnTriggerStay(Collider other)
    {
        enemyCount = 0;
        
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemyCount++;
        }

        Debug.Log("U prostoriji " + roomNum + " ima " + enemyCount + " neprijatelja.");
        // poslati gamemanageru
    }
}
