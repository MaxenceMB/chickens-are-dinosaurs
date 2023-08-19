using UnityEngine;
using System;

[Serializable] public class BackgroundLayer {
    public GameObject layer;                 // Layer avec les 3 sprites
    public float parallaxEffect;             /* Vitesse de d�placement: 1 = suit compl�tement la cam�ra (parrait immobile),
                                                                        0 = reste imobile dans le monde, (bouge aussi vite que le joueur) */
    private float length, height, startPos;  // Donn�es du layer itself

    private void Start() {
        height = layer.GetComponent<SpriteRenderer>().bounds.size.y;
        length = layer.GetComponent<SpriteRenderer>().bounds.size.x;
        startPos = layer.transform.position.x;
    }

    public float getLength() {
        return length;
    }

    public float getHeight() {
        return height;
    }

    public void setStartPos(float val) {
        startPos += val;
    }

    public float getStartPos() {
        return startPos;
    }
}
