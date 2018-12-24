using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggerController : MonoBehaviour {

    private int health;
    public GameObject ExplosionPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            Destroy(collision.gameObject);
            Instantiate(ExplosionPrefab, collision.gameObject.transform.position, Random.rotation);
            if (transform.GetChild(1).gameObject.activeSelf == false)
                gameObject.GetComponent<GameObjectDetails>().health -= collision.gameObject.GetComponent<GameObjectDetails>().damageDeal;
            else
                transform.GetChild(1).gameObject.GetComponent<GameObjectDetails>().health -= collision.gameObject.GetComponent<GameObjectDetails>().damageDeal;

        }
        if(collision.gameObject.tag == "SmallAsteroid")
        {
            Destroy(collision.gameObject);
            health -= 10;
        }
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Shield" && transform.GetChild(1).gameObject.active)
        {
            Destroy(other.gameObject);
            transform.GetChild(1).gameObject.GetComponent<ShieldController>().health += 50;
        }
    }
}
