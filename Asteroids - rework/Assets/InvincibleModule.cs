using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibleModule : MonoBehaviour {

    public int cooldown;
    public int duration;

    bool InvincibleEnabled = false;

    private float timeCooldown;
    private float timeDuration;

    // Use this for initialization
    void Start()
    {
        float timeCooldown = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Invincible") && cooldownTimer(cooldown, timeCooldown))
        {
            Debug.Log("ON");
            Invincible(false);
            InvincibleEnabled = true;
            timeDuration = Time.time;
        }
        if (cooldownTimer(duration, timeDuration) && InvincibleEnabled)
        {
            Invincible(true);
            InvincibleEnabled = false;
            timeCooldown = Time.time;
        }
    }

    public void Invincible(bool enabled)
    {
        GameObject.Find("TUES_PlayerShip").GetComponent<Collider>().enabled = enabled;
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
