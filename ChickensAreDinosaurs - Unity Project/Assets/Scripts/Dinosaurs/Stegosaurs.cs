using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stegosaurs : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Dinozorun hareket hýzý
    public float prototypeLevelDetectionRange = 1.0f; // Engel tespit aralýðý
    private bool isMovingForward = true; // Dinozorun ileri mi geri mi gittiði kontrolü

    void Update()
    {
        if (isMovingForward)
        {
            // Dinozorun ileri gitmesi
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        else
        {
            // Dinozorun geri gitmesi
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }

        // Engel kontrolü
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, prototypeLevelDetectionRange))
        {
            if (hit.collider.CompareTag("prototypeLevel"))
            {
                // Engel varsa yönü deðiþtir
                isMovingForward = !isMovingForward;
            }
        }
    }
}






