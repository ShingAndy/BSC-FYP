using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //reference
    private CharacterController controller;
    [SerializeField] private FloatingJoystick joystick; 

    //parameters
    [SerializeField] private int moveSpeed;
    [SerializeField] private int rotateSpeed;
    [SerializeField] private float gravity;
    [SerializeField] private float jump;


    private bool isGround;
    public Transform groundCheck;
    public float checkGroundRadius;
    private Vector3 vVelocity = Vector3.zero;
    public LayerMask collideLayer;

    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
        //input
        float hInput = joystick.Horizontal;
        float vInput = joystick.Vertical;

        //forward movement
        Vector3 movement = transform.forward * moveSpeed * vInput * Time.deltaTime;
        controller.Move(movement);

        //rotate movement
        transform.Rotate(Vector3.up * hInput * rotateSpeed);

        //check ground
        isGround = Physics.CheckSphere(groundCheck.position, checkGroundRadius, collideLayer);

        if (isGround && vVelocity.y < 0)
        {
            vVelocity.y = 0;
        }

        if(isGround&&Input.GetButtonDown("Jump"))
        {
            vVelocity.y += Mathf.Sqrt(jump * -2 * gravity);
        }

        //gravity
        vVelocity.y += gravity * Time.deltaTime;
        controller.Move(vVelocity * Time.deltaTime);
        

    }
}
