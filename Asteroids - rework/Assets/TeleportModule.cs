using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportModule : MonoBehaviour {


    public int cooldown;

    private float timeCooldown;

    private int displayCooldown;
    private float displayTimer;

    bool teleportEnabled = false;

    // Use this for initialization
    void Start () {
        cooldown = GameInfo.teleportTimeCooldown;
        float timeCooldown = Time.time;
        GameObject.Find("TeleportCooldown").GetComponent<UnityEngine.UI.Text>().text = cooldown.ToString();
        float displayTimer = Time.time;
        displayCooldown = cooldown;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Teleport") && cooldownTimer(cooldown, timeCooldown))
        {
            Teleport();
            teleportEnabled = true;
            timeCooldown = Time.time;

        }
        if (teleportEnabled)
        {
            displayCooldown = cooldown;
            GameObject.Find("TeleportCooldown").GetComponent<UnityEngine.UI.Text>().text = displayCooldown.ToString();
            teleportEnabled = false;
        }

        if (cooldownTimer(1f, displayTimer) && !teleportEnabled && displayCooldown > 0)
        {
            displayCooldown--;
            GameObject.Find("TeleportCooldown").GetComponent<UnityEngine.UI.Text>().text = displayCooldown.ToString();
            displayTimer = Time.time;
        }
        
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

    bool cooldownTimer(float offset, float time)
    {
        if (Time.time >= time + offset)
        {
            time = Time.time;
            return true;
        }
        return false;
    }
}
