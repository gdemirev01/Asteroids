using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour {

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
    //public void UpdateRockets()
    //{
    //    gameInfo.money -= valueLaser;
    //    gameInfo.projectileSpeed += 100;
    //    gameInfo.shotsPerSecond += 1;
    //    gameInfo.damageOfWeapon += 5;
    //}

    public void UpdateLaser()
    {
        GameInfo.money -= valueLaser;
        GameInfo.projectileSpeed += 100;
        GameInfo.shotsPerSecond += 1;
        GameInfo.damageOfWeapon += 5;
        valueLaser += 50;
        GameObject.Find("LaserLabel").GetComponent<Text>().text = valueLaser.ToString();
    }

    public void UpdateShield()
    {
        GameInfo.money -= valueShield;
        GameInfo.shieldTimeCooldown -= 1;
        GameInfo.shieldTimeDuration += 1;
        valueShield += 50;
        GameObject.Find("ShieldLabel").GetComponent<Text>().text = valueShield.ToString();

    }

    public void UpdateTeleport()
    {
        GameInfo.money -= valueTeleport;
        GameInfo.teleportTimeCooldown -= 1;
        valueTeleport += 50;
        GameObject.Find("TeleportLabel").GetComponent<Text>().text = valueTeleport.ToString();

    }

    public void UpdateHealth()
    {
        GameInfo.money -= valueHealth;
        GameInfo.health += 100;
        valueHealth += 50;
        GameObject.Find("HealthLabel").GetComponent<Text>().text = valueHealth.ToString();

    }
}
