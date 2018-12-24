using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour {
	public string TagToHit = "Asteroid";
    public GameObject DestructionFX;
    public float DestructionFXDuration = 0.5f;


    void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.CompareTag(TagToHit))
		{
			Destroy(gameObject);
            if (DestructionFX != null)
            {
                GameObject spawnedFX = Instantiate(DestructionFX, transform.position, Random.rotation);
                Destroy(spawnedFX, DestructionFXDuration);
            }
            HitReceiver hitReceiver = collision.gameObject.GetComponent<HitReceiver> ();
			if (hitReceiver) {
				hitReceiver.ReceiveHit (gameObject);

			} else {
				Destroy (collision.gameObject);
			}

		}
	}
}
