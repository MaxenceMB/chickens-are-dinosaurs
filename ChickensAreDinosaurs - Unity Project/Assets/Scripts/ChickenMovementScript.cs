using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenMovementScript : MonoBehaviour {

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;

    private enum MovementState {idle, running, jumping, falling};

    [SerializeField]
    private int runSpeed, jumpForce;

    private void Start() {
        rb     = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim   = GetComponent<Animator>();
    }

    private void Update() {

        // Movements \\
        // Run
        float directionX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(runSpeed * directionX, rb.velocity.y);

        // Jump
        if (Input.GetButtonDown("Jump")) {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }


        // Animator \\
        UpdateAnimator(directionX);
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

        if (rb.velocity.y > 0.01f) {
            state = MovementState.jumping;
        } else if (rb.velocity.y < -0.01f) {
            state = MovementState.falling;
        }

        anim.SetInteger("moveState", (int)state);
    }
}
