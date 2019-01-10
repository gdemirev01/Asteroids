using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour {
	public string[] TagsToHit;
    public GameObject DestructionFX;
    public float DestructionFXDuration = 0.5f;


    void OnCollisionEnter(Collision collision)
	{
        foreach (string x in TagsToHit)
        {
            if (collision.gameObject.tag.Equals(x))

            {
                Destroy(gameObject);
                if (DestructionFX != null)
                {
                    GameObject spawnedFX = Instantiate(DestructionFX, transform.position, Random.rotation);
                    Destroy(spawnedFX, DestructionFXDuration);
                }
                HitReceiver hitReceiver = collision.gameObject.GetComponent<HitReceiver>();
                if (hitReceiver)
                {
                    hitReceiver.ReceiveHit(gameObject);

                }
                else
                {
                    Destroy(collision.gameObject);
                }

            }
            else
            {
                Debug.Log("shit");
            }
        }
	}
}
