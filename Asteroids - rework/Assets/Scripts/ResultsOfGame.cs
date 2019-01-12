using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultsOfGame : MonoBehaviour {
    public static string result;
    public static int score;
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(result);
        transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = result;
        transform.GetChild(2).GetComponent<UnityEngine.UI.Text>().text = score.ToString();
    }
}
