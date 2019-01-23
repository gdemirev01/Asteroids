using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{

    public int money;

    public int record;

    public int health;

    public float volume;

    public int valueLaser;
    public int valueRockets;
    public int valueShield;
    public int valueTeleport;
    public int valueHealth;

    public float projectileSpeed;
    public float shotsPerSecond;

    public float rocketSpeed;
    public float rocketsPerSecond;
    public int rocketsCount;
    public int damageOfRockets;

    public int shieldTimeCooldown;
    public int shieldTimeDuration;

    public int teleportTimeCooldown;

    public int levelOfRockets;
    public int levelOfLaser;
    public int levelOfShield;
    public int levelOfTeleport;
    public int levelOfHealth;

    public PlayerData()
    {
        money = GameInfo.money;

        record = GameInfo.record;

        health = GameInfo.health;

        volume = GameInfo.volume;

        valueLaser = GameInfo.valueLaser;
        valueRockets = GameInfo.valueRockets;
        valueShield = GameInfo.valueShield;
        valueTeleport = GameInfo.valueTeleport;
        valueHealth = GameInfo.valueHealth;

        projectileSpeed = GameInfo.projectileSpeed;
        shotsPerSecond = GameInfo.shotsPerSecond;

        rocketSpeed = GameInfo.rocketSpeed;
        rocketsPerSecond = GameInfo.rocketsPerSecond;
        rocketsCount = GameInfo.rocketsCount;
        damageOfRockets = GameInfo.damageOfRockets;

        shieldTimeCooldown = GameInfo.shieldTimeCooldown;
        shieldTimeDuration = GameInfo.shieldTimeDuration;

        teleportTimeCooldown = GameInfo.teleportTimeCooldown;

        levelOfRockets = GameInfo.levelOfRockets;
        levelOfLaser = GameInfo.levelOfLaser;
        levelOfShield = GameInfo.levelOfShield;
        levelOfTeleport = GameInfo.levelOfTeleport;
        levelOfHealth = GameInfo.levelOfHealth;
    }

    public void setData()
    {
        GameInfo.money = money;

        GameInfo.record = record;

        GameInfo.health = health;

        GameInfo.volume = volume;

        GameInfo.valueLaser = valueLaser;
        GameInfo.valueRockets = valueRockets;
        GameInfo.valueShield = valueShield;
        GameInfo.valueTeleport = valueTeleport;
        GameInfo.valueHealth = valueHealth;

        GameInfo.projectileSpeed = projectileSpeed;
        GameInfo.shotsPerSecond = shotsPerSecond;

        GameInfo.rocketSpeed = rocketSpeed;
        GameInfo.rocketsPerSecond = rocketsPerSecond;
        GameInfo.rocketsCount = rocketsCount;
        GameInfo.damageOfRockets = damageOfRockets;

        GameInfo.shieldTimeCooldown = shieldTimeCooldown;
        GameInfo.shieldTimeDuration = shieldTimeDuration;

        GameInfo.teleportTimeCooldown = teleportTimeCooldown;

        GameInfo.levelOfRockets = levelOfRockets;
        GameInfo.levelOfLaser = levelOfLaser ;
        GameInfo.levelOfShield = levelOfShield;
        GameInfo.levelOfTeleport = levelOfTeleport;
        GameInfo.levelOfHealth = levelOfHealth;
    }
}
