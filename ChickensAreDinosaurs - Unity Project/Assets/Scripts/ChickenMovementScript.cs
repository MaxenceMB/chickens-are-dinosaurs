using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenMovementScript : MonoBehaviour {

    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    private enum MovementState {idle, running, jumping, falling};

    [SerializeField]
    private int runSpeed, jumpForce;

    [SerializeField]
    private LayerMask jumpableGround;

    private void Start() {
        rb     = GetComponent<Rigidbody2D>();
        coll   = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim   = GetComponent<Animator>();
    }

    private void Update() {

        // Movements \\
        // Run
        float directionX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(runSpeed * directionX, rb.velocity.y);

        // Jump
        if (Input.GetButtonDown("Jump") && isGrounded()) {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }


        // Animator \\
        UpdateAnimator(directionX);
    }

    private bool isGrounded() {
        // Makes a box just under the collider and checks if it's colliding with ground layer
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .01f, jumpableGround);
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

        // Set the animator the correct state
        anim.SetInteger("moveState", (int)state);
    }
}
