using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setVolume : MonoBehaviour {
	
	void Update () {
        GetComponent<AudioSource>().volume = GameInfo.volume;
	}
}
