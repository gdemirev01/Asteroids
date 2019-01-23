using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectDetails : MonoBehaviour {

    public int health;
    public int damageDeal;
    public int points;
    public int moneyToGive;

    private void Awake()
    {
        if(tag == "Player")
        {
            health = 100 + GameInfo.health;
            Debug.Log(health);
        }
        else if(tag == "Projectile")
        {
            damageDeal = GameInfo.damageOfWeapon;
        }
        else if(tag == "Rocket")
        {
            damageDeal = GameInfo.damageOfRockets;
        }
    }
}
