using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public float ShotsPerSecond = 10f;
    public GameObject ProjectileToSpawn;
    public Transform SpawnPosition;
    public float ProjectileSpeed;
    public float ProjectileDuration;

    private void Awake()
    {
        ProjectileSpeed = GameInfo.projectileSpeed;
        ShotsPerSecond = GameInfo.shotsPerSecond;

    }

    private float NextShotTime = 0.0f;
    private int ShieldDuration = 10;
    
    public void Shoot()
    {
        float cooldown = 1 / ShotsPerSecond;

        if (Time.time > NextShotTime)
        {
            GameObject projectile = Instantiate(ProjectileToSpawn, SpawnPosition.position, SpawnPosition.rotation);
            Rigidbody rb = projectile.GetComponent<Rigidbody>();

            rb.velocity = projectile.transform.forward * ProjectileSpeed * Time.deltaTime;
            NextShotTime = Time.time + cooldown;
        }
    }



    
}
