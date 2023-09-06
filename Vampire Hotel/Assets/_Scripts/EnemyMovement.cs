using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float speed;


    private void Update()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }



}
