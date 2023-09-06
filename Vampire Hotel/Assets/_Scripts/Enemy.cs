using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(0, 15 * Time.deltaTime, 0);
    }
}
