using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIControler : MonoBehaviour {

    public int score;
    private float healthOfShield;
    private int healthOfPlayer;
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        score = GameState.score;

        if (GameObject.Find("TUES_PlayerShip"))
            healthOfPlayer = GameObject.Find("TUES_PlayerShip").GetComponent<GameObjectDetails>().health;


        transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = "Health:     " + healthOfPlayer + "    Score:      " + score;
        
	}
}
