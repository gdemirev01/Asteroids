using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsTriggerController : MonoBehaviour {

    public GameObject AsteroidPrefab;
    public GameObject ExplosionPrefab;
    public int health = 10;
    float touched = 0.0f;
    float dc = 1.0f;
	// Use this for initialization
	void Start () {
		
	}
    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Projectile" && gameObject.tag == "Asteroid")
        {
            Debug.Log("hit");
            health -= 10;
            Destroy(other.gameObject);


        }
        else if(other.gameObject.tag == "Projectile" && this.gameObject.tag == "SmallAsteroid")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        if(health <= 0)
        {
        }

    }

    // Update is called once per frame
    void Update () {
            

    }
}
