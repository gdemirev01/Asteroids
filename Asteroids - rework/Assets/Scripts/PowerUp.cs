using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && tag == "Health")
        {
            Destroy(this.gameObject);
            other.GetComponent<GameObjectDetails>().health += 20;
        }
        if(other.tag == "Player" && tag == "Rocket")
        {
            Destroy(this.gameObject);
            other.transform.Find("RocketLauncher").GetComponent<Weapon>().rocketsCount += 2;
        }
    }


}
