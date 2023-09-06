using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController cc;
    [SerializeField] TouchJoystick joystick;
    [SerializeField] float speed;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    private void Update()
    {
        
        float x = joystick.inputVector.x;
        float z = joystick.inputVector.y;

        Vector3 move = transform.right * x + transform.forward * z;

        cc.Move(move * speed * Time.deltaTime);
    }
}
