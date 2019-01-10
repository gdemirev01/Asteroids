using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

    public GameObject spherePrefab;
    GameObject novasfera;
    private Vector3 lastPos = new Vector3(1, 1, 1);
    bool playerDown = false;
	// Use this for initialization
	void Start () {
		
	}
    public int speed = 5;
	// Update is called once per frame
	public void Update () {
		if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            Vector3 direction = new Vector3(0, 0, 1 * speed);
            spherePrefab.GetComponent<Rigidbody>().velocity = direction;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Vector3 direction = new Vector3(0, 0, -1 * speed);
            spherePrefab.GetComponent<Rigidbody>().velocity = direction;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Vector3 direction = new Vector3(-1 * speed, 0, 0);
            spherePrefab.GetComponent<Rigidbody>().velocity = direction;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Vector3 direction = new Vector3(1 * speed, 0, 1);
            spherePrefab.GetComponent<Rigidbody>().velocity = direction;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 direction = new Vector3(0, 1 * speed, 1);
            spherePrefab.GetComponent<Rigidbody>().velocity = direction;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            lastPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Destroy(novasfera);
            playerDown = true;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("asdf");
            novasfera = Instantiate(spherePrefab, lastPos, new Quaternion(0, 0, 0, 0));
            playerDown = false;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 direction = new Vector3(0, 1 * speed, 1);
            spherePrefab.GetComponent<Rigidbody>().velocity = direction;
        }
    }
}
