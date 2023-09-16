using UnityEngine;

public class ChickenMovementScript : MonoBehaviour {

    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    private float initialGravityScale;

    private enum MovementState {idle, running, jumping, falling, gliding};
    private bool doubleJump;
    private bool isGliding = false;
    [SerializeField] private int runSpeed, jumpForce;
    [SerializeField] private float glidingVelocity;

    [SerializeField] private LayerMask jumpableGround;

    private void Start() {
        rb     = GetComponent<Rigidbody2D>();
        coll   = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim   = GetComponent<Animator>();

        initialGravityScale = rb.gravityScale;
    }

    private void Update() {

        // Movements \\
        // Run
        float directionX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(runSpeed * directionX, rb.velocity.y);

        // Jump
        if (isGrounded() && !Input.GetButton("Jump")) {
            doubleJump = true;
        }

        if (Input.GetButtonDown("Jump")) {
            if (doubleJump) {
                if (!isGrounded()) {
                    doubleJump = !doubleJump;
                }
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);

                anim.Play("chickenJump_Clip", -1, 0f); // Maybe to fix later, its because i want the animation to start again on the double jump.
            }
        } 

        if (Input.GetButton("Jump") && rb.velocity.y < -0.1f) {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, -glidingVelocity);

            isGliding = true;
        } else {
            rb.gravityScale = initialGravityScale;
            isGliding = false;
        }

        // Animator \\
        UpdateAnimator(directionX);
    }

    private bool isGrounded() {
        // Makes a box just under the collider and checks if it's colliding with ground layer
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size - new Vector3(0.01f, 0.01f, 0f), 0f, Vector2.down, 0.1f, jumpableGround);
    }

    private void UpdateAnimator(float directionX) {

        MovementState state;

        // Grounded animations (Run and Idle)
        if (directionX > 0f) {
            state = MovementState.running;
            sprite.flipX = false;
        } else if (directionX < 0f) {
            state = MovementState.running;
            sprite.flipX = true;
        } else {
            state = MovementState.idle;
        }

        // Air animations (Jump and Fall)
        if (rb.velocity.y > 0.01f) {
            state = MovementState.jumping;
        } else if (rb.velocity.y < -0.01f) {
            state = MovementState.falling;
        } 
        
        if (isGliding) {
            state = MovementState.gliding;
        }

        // Set the animator the correct state
        anim.SetInteger("moveState", (int)state);
    }
}
