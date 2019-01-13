using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultController : MonoBehaviour {

    private int prevScore;
	// Use this for initialization
	void Start () {
        prevScore = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if(GameState.score > prevScore + 500)
        {
            Debug.Log("Boosto");
            prevScore = GameState.score;
            IncreaseDifficulty();
        }
	}

    void IncreaseDifficulty()
    {
        AsteroidSpawner spawner = GameObject.Find("AsteroidSpawner").GetComponent<AsteroidSpawner>();
        spawner.healthOfAsteroids += 10;
        spawner.damageDealOfAsteroids += 10;
        spawner.timeBetweenSpawns -= 1;
    }
}
