using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportModule : MonoBehaviour {


    public int cooldown;

    private float timeCooldown;

    private int displayCooldown;
    private float displayTimer;

    bool teleportEnabled = false;

    private bool firstLaunch = true;

    // Use this for initialization
    void Start () {
        cooldown = GameInfo.teleportTimeCooldown;
        float timeCooldown = Time.time;
        GameObject.Find("TeleportCooldown").GetComponent<UnityEngine.UI.Text>().text = "0";
        float displayTimer = Time.time;
        displayCooldown = cooldown;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Teleport") && firstLaunch)
        {
            if (Teleport())
            {
                teleportEnabled = true;
                timeCooldown = Time.time;
                firstLaunch = false;
            }
        }

        else if (Input.GetButtonDown("Teleport") && cooldownTimer(cooldown, timeCooldown))
        {
            if (Teleport())
            {
                teleportEnabled = true;
                timeCooldown = Time.time;
            }
        }

        if (teleportEnabled)
        {
            displayCooldown = cooldown;
            GameObject.Find("TeleportCooldown").GetComponent<UnityEngine.UI.Text>().text = displayCooldown.ToString();
            teleportEnabled = false;
        }

        if (cooldownTimer(1f, displayTimer) && !teleportEnabled && displayCooldown > 0 && !firstLaunch)
        {
            displayCooldown--;
            GameObject.Find("TeleportCooldown").GetComponent<UnityEngine.UI.Text>().text = displayCooldown.ToString();
            displayTimer = Time.time;
        }
        
    }

    public bool Teleport()
    {
        bool isTeleported = false;

        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        if (verticalInput != 0 || horizontalInput != 0)
        {
            GameObject.Find("TUES_PlayerShip").transform.position = this.gameObject.transform.position;
            isTeleported = true;
        }

        return isTeleported;
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
