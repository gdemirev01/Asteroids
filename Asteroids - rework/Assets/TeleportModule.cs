using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportModule : MonoBehaviour {


    public int cooldown;

    private float time;

	// Use this for initialization
	void Start () {
        float time = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Teleport") && cooldownTimer())
            Teleport();
    }

    public void Teleport()
    {
        float playerCameraOffset = Camera.main.transform.position.y - transform.position.y;
        Vector3 mousePositionScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, playerCameraOffset);
        Vector3 mousePositionWorldSpace = Camera.main.ScreenToWorldPoint(mousePositionScreenSpace);

        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        if (verticalInput != 0 || horizontalInput != 0)
            GameObject.Find("TUES_PlayerShip").transform.position = mousePositionWorldSpace;
    }

    bool cooldownTimer()
    {
        if (Time.time >= time + cooldown)
        {
            time = Time.time;
            return true;
        }
        return false;
    }
}
