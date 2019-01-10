using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour {
    public GameObject sphere;
	// Use this for initialization
	void Start () {
        sphere = GameObject.Find("Sphere");
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = sphere.transform.position;
	}
}
