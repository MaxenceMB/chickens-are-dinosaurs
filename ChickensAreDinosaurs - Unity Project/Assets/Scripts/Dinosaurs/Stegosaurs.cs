using UnityEngine;

public class Stegosaurs : MonoBehaviour {
    public float moveSpeed = 5.0f; // Dinozorun hareket h�z�
    public float prototypeLevelDetectionRange = 1.0f; // Engel tespit aral���
    private bool isMovingForward = true; // Dinozorun ileri mi geri mi gitti�i kontrol�

    void Update() {
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

        // Engel kontrol�
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, prototypeLevelDetectionRange))
        {
            if (hit.collider.CompareTag("prototypeLevel"))
            {
                // Engel varsa y�n� de�i�tir
                isMovingForward = !isMovingForward;
            }
        }
    }
}






