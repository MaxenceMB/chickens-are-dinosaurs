using UnityEngine;
using System;

public class DinosaurScript : MonoBehaviour {

    [Header("Dinosaur object")]
    [SerializeField] private DinoObject dinoObject;
    [Range(0, 15)][SerializeField] float patrolRange = 1f;

    [Header("Game values")]
    [SerializeField] private float moveSpeed = 5f;

    // Sprite and movement variables
    private SpriteRenderer spr;
    private Vector2 direction;
    private bool facingRight = true;

    // Patrol variables
    private Vector2 rangeBegin, rangeEnd;
    private Vector2 moveSpot;
    private float waitTime;

    private RaycastHit hit;
    
    private void Start() {
        // Patrol start 
        rangeBegin = new Vector2(transform.position.x - patrolRange/2, transform.position.y);
        rangeEnd   = new Vector2(transform.position.x + patrolRange/2, transform.position.y);

        waitTime = 3f;
        moveSpot = new Vector2(UnityEngine.Random.Range(rangeBegin.x, rangeEnd.x), transform.position.y - 0.1f);

        // Sprite assignment
        spr = this.GetComponent<SpriteRenderer>();
        spr.sprite = dinoObject.getSprite();
        CheckDir();
    }

    private void Update() {
        moveSpot.y = transform.position.y;
        transform.position = Vector2.MoveTowards(transform.position, moveSpot, moveSpeed*Time.deltaTime);

        if(Vector3.Distance(transform.position, moveSpot) < 1f) {
            if(waitTime <= 0) {
                moveSpot = new Vector2(UnityEngine.Random.Range(rangeBegin.x, rangeEnd.x), transform.position.y);
                CheckDir();
                waitTime = GenerateRandomTime();
            } else {
                waitTime -= Time.deltaTime;
            }
        }

        CheckWalls();
    }

    private void CheckWalls() {
        Vector3 raycastDir   = (facingRight) ? Vector3.right : Vector3.left;
        Vector3 raycastStart = transform.position - new Vector3(0f, 1f, 0f);
        Vector3 raycastEnd   = raycastStart + raycastDir;
        
        RaycastHit2D hit = Physics2D.Raycast(raycastEnd, raycastDir, 0.075f);
        Debug.DrawLine(raycastStart, raycastEnd, Color.green);

        if (hit.collider != null) {
            if (hit.transform.tag == "Level") {
                moveSpot = new Vector2(UnityEngine.Random.Range(rangeBegin.x, rangeEnd.x), transform.position.y);
                CheckDir();
            }
        }
    }

    private void CheckDir() {
        if(moveSpot.x > transform.position.x) {
            facingRight = true;
            spr.flipX = true;
        } else {
            facingRight = false;
            spr.flipX = false;
        }
    }

    private float GenerateRandomTime() {
        System.Random rand = new System.Random();
        double min = 5;
        double max = 10;
        double range = max - min;
        
        double sample = rand.NextDouble();
        double scaled = (sample * range) + min;
        return (float)scaled;
    }

    private void OnDrawGizmosSelected() {
        Vector3 begin = new Vector3(transform.position.x - patrolRange/2, transform.position.y - 0.5f, transform.position.z);
        Vector3 end   = new Vector3(transform.position.x + patrolRange/2, transform.position.y - 0.5f, transform.position.z);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(begin, end);
    }

}
