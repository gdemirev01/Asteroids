using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour
{

    private void Update()
    {
        GameObject.Find("money").GetComponent<Text>().text = GameInfo.money.ToString();

        GameObject.Find("RocketLabel").GetComponent<Text>().text = GameInfo.valueRockets.ToString();
        GameObject.Find("HealthLabel").GetComponent<Text>().text = GameInfo.valueHealth.ToString();
        GameObject.Find("ShieldLabel").GetComponent<Text>().text = GameInfo.valueShield.ToString();
        GameObject.Find("TeleportLabel").GetComponent<Text>().text = GameInfo.valueTeleport.ToString();
        GameObject.Find("LaserLabel").GetComponent<Text>().text = GameInfo.valueLaser.ToString();
    }

    public void UpdateRockets()
    {
        if (GameInfo.money >= GameInfo.valueRockets)
        {
            SaveSystem.SavePlayer();
            GameInfo.levelOfRockets++;
            if(GameInfo.levelOfRockets <= 15)
            {
                GameInfo.money -= GameInfo.valueRockets;
                Mathf.Clamp(GameInfo.rocketSpeed += 100, 500, 1500);
                GameInfo.rocketsPerSecond += 1;
                GameInfo.damageOfRockets += 5;
                GameInfo.rocketsCount = GameInfo.rocketsCount += 2;
                GameInfo.valueRockets += 50;
            }
            else
            {
                GameInfo.levelOfRockets = 16;
            }
            
        }
    }

    public void UpdateLaser()
    {
        if (GameInfo.money >= GameInfo.valueLaser)
        {
            SaveSystem.SavePlayer();
            GameInfo.levelOfLaser++;
            if (GameInfo.levelOfLaser <= 15)
            {
                GameInfo.money -= GameInfo.valueLaser;
                GameInfo.projectileSpeed += 100;
                GameInfo.shotsPerSecond += 1;
                GameInfo.damageOfWeapon += 5;
                GameInfo.valueLaser += 50;
            }
            else
            {
                GameInfo.levelOfLaser = 16;
            }
        }
    }

    public void UpdateShield()
    {
        if (GameInfo.money >= GameInfo.valueShield)
        {
            SaveSystem.SavePlayer();
            GameInfo.levelOfShield++;
            if (GameInfo.levelOfShield <= 15)
            {
                GameInfo.money -= GameInfo.valueShield;
                GameInfo.shieldTimeCooldown -= 1;
                GameInfo.shieldTimeDuration += 1;
                GameInfo.valueShield += 50;
            }
            else
            {
                GameInfo.levelOfShield = 16;
            }
        }
    }

    public void UpdateTeleport()
    {
        if (GameInfo.money >= GameInfo.valueTeleport)
        {
            SaveSystem.SavePlayer();
            GameInfo.levelOfTeleport++;
            if (GameInfo.levelOfTeleport <= 15)
            {
                GameInfo.money -= GameInfo.valueTeleport;
                GameInfo.teleportTimeCooldown -= 1;
                GameInfo.valueTeleport += 50;
            }
            else
            {
                GameInfo.levelOfTeleport = 16;
            }
        }

    }

    public void UpdateHealth()
    {
        if (GameInfo.money >= GameInfo.valueHealth)
        {
            SaveSystem.SavePlayer();
            GameInfo.levelOfHealth++;
            if (GameInfo.levelOfHealth <= 15)
            {
                GameInfo.money -= GameInfo.valueHealth;
                GameInfo.health += 100;
                GameInfo.valueHealth += 50;
            }
            else
            {
                GameInfo.levelOfHealth = 16;
            }
        }
    }
}
