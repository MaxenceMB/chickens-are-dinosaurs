using UnityEngine;
using System;

[Serializable]
public class BackgroundLayer {
    public GameObject layer;            // Layer avec les 3 sprites
    public float height;                // hauteur ajoutée 
    public float parallaxEffect;        /* Vitesse de déplacement: 1 = suit complètement la caméra (parrait immobile),
                                                                   0 = reste imobile dans le monde, (bouge aussi vite que le joueur) */
    private float dimLength, startPos;  // Données du layer itself

    public void Start() {
        this.dimLength = layer.GetComponent<SpriteRenderer>().bounds.size.x;
        this.startPos  = layer.transform.position.x;
    }

    public float getLength() {
        return dimLength;
    }

    public void setStartPos(float val) {
        this.startPos += val;
    }

    public float getStartPos() {
        return this.startPos;
    }
}
