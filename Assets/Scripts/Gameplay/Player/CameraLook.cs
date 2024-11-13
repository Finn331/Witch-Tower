using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    private float xMove;
    private float yMove;
    private float xRotation;
    [SerializeField] private Transform playerBody;
    public Vector2 lockAxis;
    public float sensitivity = 10f;
    void Start()
    {
        
    }

    
    void Update()
    {
        xMove = lockAxis.x * sensitivity * Time.deltaTime;
        yMove = lockAxis.y * sensitivity * Time.deltaTime;
        xRotation -= yMove;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * xMove);
    }
}
