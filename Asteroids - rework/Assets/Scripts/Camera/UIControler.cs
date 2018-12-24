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

        if(GameObject.Find("Shield"))
            healthOfShield = GameObject.Find("Shield").GetComponent<GameObjectDetails>().health;

        transform.GetChild(2).GetComponent<UnityEngine.UI.Text>().text = "Health:     " + healthOfPlayer + "    Score:      " + score;
        if(healthOfPlayer <= 0)
        {
            transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = "YOU LOSE";
            transform.GetChild(0).gameObject.SetActive(true);
        }
        transform.GetChild(1).gameObject.GetComponent<UnityEngine.UI.Text>().text = "Shield:     " + healthOfShield;
        
	}
}
