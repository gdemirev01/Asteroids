using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitReceiver : MonoBehaviour {
	public GameObject ObjectToSpawnOnDeath;
	public GameObject DestructionFX;
	public float SpawnDistance = 2;
	public float DeflectionAngle = 45;
	public float DestructionFXDuration = 0.5f;
	public bool DebugDraw = false;
    public int moneyCollected = 0;

    public void ReceiveHit(GameObject damageDealer)
	{
        if(tag == "Player" && transform.FindChild("ShieldModule"))
        {

            if (GameObject.Find("ShieldModule").GetComponent<Collider>().enabled == true)
            {
                Debug.Log("are we there yet?");
                
            }
            else
            {
                var damageDealt = damageDealer.GetComponent<GameObjectDetails>().damageDeal;
                GetComponent<GameObjectDetails>().health -= damageDealt;
            }
        }
        else
        {
            var damageDealt = damageDealer.GetComponent<GameObjectDetails>().damageDeal;
            GetComponent<GameObjectDetails>().health -= damageDealt;
        }
        
        if (GetComponent<GameObjectDetails>().health <= 0)
        {
            GameObject.Find("EventSystem").GetComponent<GameState>().CheckState();
            DestroyObject(damageDealer);
            GameState.score += GetComponent<GameObjectDetails>().points;
            GameInfo.money += GetComponent<GameObjectDetails>().moneyToGive;
            moneyCollected += GetComponent<GameObjectDetails>().moneyToGive;
            GameObject.Find("Money").GetComponent<Text>().text = moneyCollected.ToString();
        }
    }

    void DestroyObject(GameObject damageDealer)
    {
        if (ObjectToSpawnOnDeath != null)
        {
            Vector3 hitDirection = transform.position - damageDealer.transform.position;
            hitDirection.Normalize();
            if (DebugDraw)
            {
                Debug.DrawLine(damageDealer.transform.position, transform.position, Color.red, 2.0f);
            }
            SpawnDeathObject(hitDirection, -DeflectionAngle);
            SpawnDeathObject(hitDirection, DeflectionAngle);
        }
        if (DestructionFX != null)
        {
            GameObject spawnedFX = Instantiate(DestructionFX, transform.position, Random.rotation);
            Destroy(spawnedFX, DestructionFXDuration);
        }
        Destroy(gameObject);
    }

private void SpawnDeathObject(Vector3 hitDirection, float angle)
	{
		Vector3 spawnDirection = Quaternion.AngleAxis (angle, Vector3.up) * hitDirection;
		Vector3 spawnPosition = transform.position + spawnDirection * SpawnDistance;
		if (DebugDraw) {
			Debug.DrawLine (transform.position, spawnPosition, Color.green, 2.0f);
		}

		GameObject spawnedObject = Instantiate(ObjectToSpawnOnDeath, spawnPosition, Random.rotation);
		var asteroidMovementController = spawnedObject.GetComponent<AsteroidMovementController>();
		if (asteroidMovementController) {
			asteroidMovementController.InitialDirection = spawnDirection;
		}
	}
}
