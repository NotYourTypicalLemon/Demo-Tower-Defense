using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D BodyPlayer;
    [SerializeField] float Speed = 100;
    public SpriteRenderer spriteRenderer; // Assign in Inspector
    public Animator anim;

    private float horizontalInput;
    private float verticalInput;
    private Vector3 movement;

    private void Start()
    {
        if (anim == null)
            anim = GetComponent<Animator>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // Determine if player is moving
        bool isMoving = horizontalInput != 0 || verticalInput != 0;
        anim.SetBool("Moving", isMoving);

        // Flip sprite only if horizontal movement
        if (horizontalInput < 0)
            spriteRenderer.flipX = true;
        else if (horizontalInput > 0)
            spriteRenderer.flipX = false;
    }

    private void FixedUpdate()
    {
        movement = new Vector3(horizontalInput, verticalInput, 0).normalized;
        BodyPlayer.linearVelocity = new Vector2(movement.x * Speed, movement.y * Speed) * Time.fixedDeltaTime;
    }
}
