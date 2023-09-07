using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] TouchJoystick joystick;
    CharacterController cc;
    [SerializeField] float speed;
    Vector3 dir = Vector3.zero;
    public int room = 0;

    [Header("Model")]
    [SerializeField] GameObject model;
    [SerializeField] float rotSpeed = 600f;
    Quaternion rot;

    //[Header("Animations")]

    private void Start()
    {
        cc = GetComponent<CharacterController>();
        rot = Quaternion.LookRotation(dir);
    }

    private void Update()
    {
        
        dir.x = joystick.inputVector.x;
        dir.z = joystick.inputVector.y;

        Vector3 move = transform.right * dir.x + transform.forward * dir.z;

        if (dir != Vector3.zero)
        {
            rot = Quaternion.LookRotation(dir);
        }
        else
        {
            rot = model.transform.rotation;
        }

        model.transform.rotation = Quaternion.RotateTowards(model.transform.rotation, rot, rotSpeed * Time.deltaTime);

        cc.Move(move * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i <= 8; i++)
        {
            if (other.CompareTag("Room" + i))
            {
                room = i;
            }
        }
    }
}
