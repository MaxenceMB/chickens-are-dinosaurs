using UnityEngine;
using System;
using UnityEngine.UIElements;

public class ParallaxBackgroundScript : MonoBehaviour {

    
    [SerializeField] private GameObject cam;
    [SerializeField] public BackgroundLayer[] Layers;

    [SerializeField] public GameObject bottomSprite;
    [SerializeField] public Color bottomColor;

    private void Start() {
        // Getting camera's dimensions
        Camera camera = cam.GetComponent<Camera>();
        float camHeightDimensions = 2f * camera.orthographicSize;
        float camWidthDimensions = camHeightDimensions * camera.aspect;

        // Making bottom sprite
        SpriteRenderer render = bottomSprite.GetComponent<SpriteRenderer>();

        bottomSprite.transform.localScale = new Vector3(camWidthDimensions, 5, bottomSprite.transform.localScale.z);
        render.color = bottomColor;
        render.sortingOrder = Layers.Length;
    }

    void Update() {
        foreach (BackgroundLayer l in Layers) {
            float temp = (cam.transform.position.x * (1 - l.parallaxEffect));
            float dist = (cam.transform.position.x * l.parallaxEffect);

            l.layer.transform.position = new Vector3(l.getStartPos() + dist,
                                                     cam.transform.position.y * l.parallaxEffect + l.height,
                                                     transform.position.z
                                                     );

            if (temp > l.getStartPos() + l.getLength()) l.setStartPos(l.getLength());
            else if (temp < l.getStartPos() - l.getLength()) l.setStartPos(-l.getLength());
        }

        bottomSprite.transform.position = new Vector3(cam.transform.position.x,
                                                      Layers[Layers.Length - 1].layer.GetComponent<SpriteRenderer>().bounds.min.y - 2.5f,
                                                      0
                                                      );
    }

}
