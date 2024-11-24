using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] FixedJoystick joystick;
    public float moveSpeed;
    public float jumpForce;

    private CharacterController controller;
    private Rigidbody rb;
    private bool isGrounded;

    // Panjang ray untuk deteksi tanah
    public float groundCheckDistance = 0.1f;

    // LayerMask untuk mendeteksi ground
    [SerializeField] LayerMask groundLayer;

    // GameObject untuk titik awal raycast
    [SerializeField] Transform groundCheck;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Pergerakan pemain
        Vector3 move = transform.right * joystick.Horizontal + transform.forward * joystick.Vertical;
        controller.Move(move * moveSpeed * Time.deltaTime);

        // Deteksi apakah pemain berada di tanah menggunakan groundCheck
        if (groundCheck != null)
        {
            isGrounded = Physics.Raycast(groundCheck.position, Vector3.down, groundCheckDistance, groundLayer);
        }
        else
        {
            Debug.LogWarning("GroundCheck transform belum diatur!");
        }

        // Debug ray untuk melihat deteksi tanah di Scene view
        if (groundCheck != null)
        {
            Debug.DrawRay(groundCheck.position, Vector3.down * groundCheckDistance, isGrounded ? Color.green : Color.red);
        }
    }

    public void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
