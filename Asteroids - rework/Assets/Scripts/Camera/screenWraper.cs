using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenWraper : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        Vector3 viewPortPos = Camera.main.WorldToViewportPoint(gameObject.transform.position);
        bool wrapped = false;

        for(int i = 0; i < 2; ++i) {
            if(viewPortPos[i] > 1 || viewPortPos[i] < 0)
            {
                viewPortPos[i] = viewPortPos[i] - Mathf.Floor(viewPortPos[i]);
                wrapped = true;
            }
        }

        if(wrapped)
        {
            wrapped = false;
            Vector3 newPos = Camera.main.ViewportToWorldPoint(viewPortPos);
            transform.position = newPos;
        }

        
	}
}
