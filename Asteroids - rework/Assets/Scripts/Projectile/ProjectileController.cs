using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {

    public int ProjectileDuration;
	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, ProjectileDuration);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
