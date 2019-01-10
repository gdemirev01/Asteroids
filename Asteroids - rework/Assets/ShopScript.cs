using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour
{

    private int valueLaser = 10;
    private int valueRockets = 10;
    private int valueShield = 10;
    private int valueTeleport = 10;
    private int valueHealth = 10;


    private void Start()
    {
    }

    private void Update()
    {
        GameObject.Find("money").GetComponent<Text>().text = GameInfo.money.ToString();
    }

    public void UpdateRockets()
    {
        if (GameInfo.money >= valueRockets)
        {
            GameInfo.money -= valueRockets;
            GameInfo.rocketSpeed += 100;
            GameInfo.rocketsPerSecond += 1;
            GameInfo.damageOfRockets += 5;
            valueRockets += 50;
            GameObject.Find("RocketLabel").GetComponent<Text>().text = valueRockets.ToString();
        }
    }

    public void UpdateLaser()
    {
        if (GameInfo.money >= valueLaser)
        {
            GameInfo.money -= valueLaser;
            GameInfo.projectileSpeed += 100;
            GameInfo.shotsPerSecond += 1;
            GameInfo.damageOfWeapon += 5;
            valueLaser += 50;
            GameObject.Find("LaserLabel").GetComponent<Text>().text = valueLaser.ToString();
        }
    }

    public void UpdateShield()
    {
        if (GameInfo.money >= valueShield)
        {
            GameInfo.money -= valueShield;
            GameInfo.shieldTimeCooldown -= 1;
            GameInfo.shieldTimeDuration += 1;
            valueShield += 50;
            GameObject.Find("ShieldLabel").GetComponent<Text>().text = valueShield.ToString();
        }
    }

    public void UpdateTeleport()
    {
        if (GameInfo.money >= valueTeleport)
        {
            GameInfo.money -= valueTeleport;
            GameInfo.teleportTimeCooldown -= 1;
            valueTeleport += 50;
            GameObject.Find("TeleportLabel").GetComponent<Text>().text = valueTeleport.ToString();
        }

    }

    public void UpdateHealth()
    {
        if (GameInfo.money >= valueHealth)
        {
            GameInfo.money -= valueHealth;
            GameInfo.health += 100;
            valueHealth += 50;
            GameObject.Find("HealthLabel").GetComponent<Text>().text = valueHealth.ToString();
        }
    }
}
