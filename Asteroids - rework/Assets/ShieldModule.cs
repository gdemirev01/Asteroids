using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldModule : MonoBehaviour {

    public int cooldown;
    public int duration;

    bool shieldEnabled = false;

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
        if (Input.GetButtonDown("Shield") && cooldownTimer(cooldown, timeCooldown))
        {
            Shield(true);
            shieldEnabled = true;
            timeDuration = Time.time;
        }
        if (cooldownTimer(duration, timeDuration) && shieldEnabled)
        {
            Shield(false);
            Debug.Log("asdf");
            shieldEnabled = false;
            timeCooldown = Time.time;
        }
    }

    public void Shield(bool enable)
    {
        GetComponent<MeshRenderer>().enabled = enable;
        GetComponent<MeshRenderer>().enabled = enable;
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
