using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //reference
    private CharacterController controller;
    [SerializeField] private FloatingJoystick joystickY;
    [SerializeField] private FloatingJoystick joystickX;

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

    private Animator animator;
    private bool isJump = false;

    public AudioClip[] sounds;
    private AudioSource audioSource;

    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        animator = gameObject.GetComponent<Animator>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        //input
        //if the player use right joystick to rotate, use the value of right joystick
        float hInput = joystickX.Horizontal == 0 ? joystickY.Horizontal : joystickX.Horizontal*1.4f;
        float vInput = joystickY.Vertical;

        //as the player walk to the back, the value will be negative
        float walking = vInput < 0 ? vInput * -1 : vInput;
        animator.SetFloat("walking", walking);

        //if move stop navigation
        if (hInput != 0 || vInput != 0)
        {
            Player player = FindObjectOfType<Player>();
            player.StopNav();
        }

        //navigation mode on
        if (!controller.enabled)
            return;

        //forward movement
        Vector3 movement = transform.forward * moveSpeed * vInput * Time.deltaTime;

        //if player running
        if (walking > 0.7)
        {
            movement *= 2f;
        }

        controller.Move(movement);

        //manage the sound effect of walking
        if (vInput > 0 && !audioSource.isPlaying)
        {
            audioSource.clip = sounds[0];
            audioSource.Play();
        }
        else if (vInput == 0 && audioSource.clip == sounds[0])
        {
            audioSource.Pause();
        }

        //rotate movement
        transform.Rotate(Vector3.up * hInput * rotateSpeed);

        //check ground
        isGround = Physics.CheckSphere(groundCheck.position, checkGroundRadius, collideLayer);

        if (isGround && vVelocity.y < -5)
        {
            vVelocity.y = 0;
        }

        //gravity
        vVelocity.y += gravity * Time.deltaTime;
        controller.Move(vVelocity * Time.deltaTime);
    }

    //set the jump function
    public void Jump()
    {
        if (isGround && !isJump)
        {
            isJump = true;
            animator.SetTrigger("jump");
            Invoke("SetJump", 0.5f);
        }
    }

    private void SetJump()
    {
        vVelocity.y += Mathf.Sqrt(jump * -1 * gravity);
    }


    //set the drop sound after jump
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 6 && isJump)
        {
            isJump = false;
            audioSource.clip = sounds[1];
            audioSource.Play();
            Invoke("StopSound", 0.1f);
        }
    }

    private void StopSound()
    {
        audioSource.Stop();
    }
}
