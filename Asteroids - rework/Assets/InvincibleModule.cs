using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibleModule : MonoBehaviour {

    public int cooldown;
    public int duration;

    private int displayCooldown;
    private float displayTimer;

    bool InvincibleEnabled = false;

    private float timeCooldown;
    private float timeDuration;

    // Use this for initialization
    void Start()
    {
        GameObject.Find("InvincibleCooldown").GetComponent<UnityEngine.UI.Text>().text = cooldown.ToString();
        float timeCooldown = Time.time;
        float displayTimer = Time.time;
        displayCooldown = cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Invincible") && cooldownTimer(cooldown, timeCooldown))
        {
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

        if (cooldownTimer(1f, displayTimer) && !InvincibleEnabled && displayCooldown > 0)
        {
            displayCooldown--;
            GameObject.Find("InvincibleCooldown").GetComponent<UnityEngine.UI.Text>().text = displayCooldown.ToString();
            displayTimer = Time.time;

        }
        if(InvincibleEnabled)
        {
            displayCooldown = cooldown;
            GameObject.Find("InvincibleCooldown").GetComponent<UnityEngine.UI.Text>().text = displayCooldown.ToString();
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
            Debug.Log("asdf");
            time = Time.time;
            return true;
        }
        return false;
    }
}
