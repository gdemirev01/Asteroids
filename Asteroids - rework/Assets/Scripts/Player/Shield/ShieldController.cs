using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour {

    public int health;
	// Update is called once per frame
	void Update () {
        health = gameObject.GetComponent<GameObjectDetails>().health;
        ChangeColor(health);
    }

    void ChangeColor(int health)
    {
        if (health <= 30)
            GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.yellow);
        if (health <= 10)
            GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red);
        if (health > 30)
        {
            GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.green);
        }
    }
}
