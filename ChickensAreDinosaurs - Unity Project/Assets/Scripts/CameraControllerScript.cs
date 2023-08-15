using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerScript : MonoBehaviour {

    [SerializeField] private Transform player;
    [SerializeField] private float cameraHeight;
    private void Update() {
        transform.position = new Vector3(player.position.x, player.position.y + cameraHeight, transform.position.z);
    }
}
