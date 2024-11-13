using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public FixedJoystick joystick;
    public float moveSpeed = 5f;
    
    private CharacterController controller;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    
    void Update()
    {
        Vector3 Move = transform.right * joystick.Horizontal + transform.forward * joystick.Vertical;
        controller.Move(Move * moveSpeed * Time.deltaTime);
    }
}
