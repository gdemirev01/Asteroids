using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitReceiver : MonoBehaviour {
	public GameObject ObjectToSpawnOnDeath;
    public GameObject PowerUpToSpawnOnDeath;
	public GameObject DestructionFX;
	public float SpawnDistance = 2;
	public float DeflectionAngle = 45;
	public float DestructionFXDuration = 0.5f;
	public bool DebugDraw = false;
    public int moneyCollected = 0;

    public void ReceiveHit(GameObject damageDealer)
	{
        if(tag == "Player" && transform.Find("ShieldModule"))
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

            if (GameState.score > GameInfo.record)
                GameInfo.record = GameState.score;

            GameInfo.money += GetComponent<GameObjectDetails>().moneyToGive;
            moneyCollected += GetComponent<GameObjectDetails>().moneyToGive;
            var allMoney = 0;
            int.TryParse(GameObject.Find("Money").GetComponent<Text>().text, out allMoney);
            GameObject.Find("Money").GetComponent<Text>().text = (allMoney + moneyCollected).ToString();
        }
    }

    void DestroyObject(GameObject damageDealer)
    {
        var rand = Random.Range(1, 10);
        Debug.Log(rand);

        if (ObjectToSpawnOnDeath != null && rand != 7)
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
        else if(rand == 7 && PowerUpToSpawnOnDeath)
        {
            Instantiate(PowerUpToSpawnOnDeath, transform.position, transform.rotation);
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
