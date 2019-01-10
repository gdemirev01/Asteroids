using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldModule : MonoBehaviour {

    public int cooldown;
    public int duration;

    private int displayCooldown;
    private float displayTimer;

    bool shieldEnabled = false;

    private float timeCooldown;
    private float timeDuration;

    // Use this for initialization
    void Start()
    {
        cooldown = GameInfo.shieldTimeCooldown;
        duration = GameInfo.shieldTimeDuration;
        float timeCooldown = Time.time;
        float displayTimer = Time.time;
        displayCooldown = cooldown;
        GameObject.Find("ShieldCooldown").GetComponent<UnityEngine.UI.Text>().text = cooldown.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Shield") && cooldownTimer(cooldown, timeCooldown))
        {
            Shield(true);
            shieldEnabled = true;
            timeDuration = Time.time;
        }
        if (cooldownTimer(duration, timeDuration) && shieldEnabled)
        {
            Shield(false);
            shieldEnabled = false;
            timeCooldown = Time.time;
        }

        if (cooldownTimer(1f, displayTimer) && !shieldEnabled && displayCooldown > 0)
        {
            displayCooldown--;
            GameObject.Find("ShieldCooldown").GetComponent<UnityEngine.UI.Text>().text = displayCooldown.ToString();
            displayTimer = Time.time;

        }
        if (shieldEnabled)
        {
            displayCooldown = cooldown;
            GameObject.Find("ShieldCooldown").GetComponent<UnityEngine.UI.Text>().text = displayCooldown.ToString();
        }
    }

    public void Shield(bool enable)
    {
        GetComponent<MeshRenderer>().enabled = enable;
        GetComponent<Collider>().enabled = enable;
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
