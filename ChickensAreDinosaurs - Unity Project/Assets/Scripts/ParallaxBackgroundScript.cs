using System.Collections.Generic;
using UnityEngine;
using System;

public class ParallaxBackgroundScript : MonoBehaviour {

    
    [SerializeField] private GameObject cam;

    [Serializable]
    public class BackgroundLayer {
        public GameObject layer;
        public float parallaxEffect;

        public float length, startpos;
    }

    // Start is called before the first frame update
    void Start() {
        List<BackgroundLayer> layers = new List<BackgroundLayer>();

        foreach (BackgroundLayer l in layers) {
            l.startpos = l.layer.transform.position.x;
            l.length = l.layer.GetComponent<SpriteRenderer>().bounds.size.x;
        }
        
    }

    // Update is called once per frame
    void Update() {
        /*
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

        if (temp > startpos + length) startpos += length;
        else if (temp < startpos - length) startpos -= length;
        */
    }
}
