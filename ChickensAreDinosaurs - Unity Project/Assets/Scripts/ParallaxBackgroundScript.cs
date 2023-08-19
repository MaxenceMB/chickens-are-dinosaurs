using UnityEngine;
using System;
using UnityEngine.UIElements;

public class ParallaxBackgroundScript : MonoBehaviour {

    
    [SerializeField] private GameObject cam;
    public BackgroundLayer[] Layers;

    void Update() {
        foreach (BackgroundLayer l in Layers) {
            float temp = (cam.transform.position.x * (1 - l.parallaxEffect));
            float dist = (cam.transform.position.x * l.parallaxEffect);

            l.layer.transform.position = new Vector3(l.getStartPos() + dist,
                                                     cam.transform.position.y * l.parallaxEffect,
                                                     transform.position.z
                                                     );

            if (temp > l.getStartPos() + l.getLength()) l.setStartPos(l.getLength());
            else if (temp < l.getStartPos() - l.getLength()) l.setStartPos(-l.getLength());
        }
    }

}
