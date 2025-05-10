using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D BodyPlayer;
    public float Speed = 30;
    public SpriteRenderer spriteRenderer; // Drag your SpriteRenderer here in Inspector
    public Animator anim;

    private float horizontalInput;
    private float verticalInput;
    private Vector3 movement;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Moving();
    }

    private void Moving()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // Flip sprite based on horizontal movement
        if (horizontalInput < 0)
            spriteRenderer.flipX = false;
        else if (horizontalInput > 0)
            spriteRenderer.flipX = true;

        anim.SetBool("Moving", true);
    }

    private void FixedUpdate()
    {
        movement = new Vector3(horizontalInput, verticalInput, 0).normalized;
        BodyPlayer.linearVelocity = new Vector2(movement.x * Speed, movement.y * Speed) * Time.fixedDeltaTime;
    }
}
