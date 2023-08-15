using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenMovementScript : MonoBehaviour {

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;

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
        if (directionX > 0f) {
            anim.SetBool("isRunning", true);
            sprite.flipX = false;
        } else if (directionX < 0f) {
            anim.SetBool("isRunning", true);
            sprite.flipX = true;
        } else {
            anim.SetBool("isRunning", false);
        }
    }
}
