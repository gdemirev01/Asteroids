using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemycontroller : MonoBehaviour {
    GameObject player;
    float step;
    public float speed;
    float time;
    public float speedOfFire;
    Rigidbody rb;
    // Use this for initialization

    private void Start()
    {
        AsteroidSpawner.Instance.RegisterPlayer(gameObject);
        player = GameObject.Find("TUES_PlayerShip");
        step = speed * Time.deltaTime;
        time = Time.time;
        rb = GetComponent<Rigidbody>();
    }

    void OnDestroy()
    {
        AsteroidSpawner.Instance.UnregisterPlayer(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
        Shoot();
        Move();

    }

    private void FixedUpdate()
    {
    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.GetComponent<Transform>().position, step);
        //rb.MovePosition(player.transform.position + transform.forward * step);
        transform.LookAt(player.transform);
        //rb.AddForce(Vector3.forward * speed);
    }

    void Shoot()
    {
        if (Time.time > time + speedOfFire)
        {
            transform.FindChild("Weapon").GetComponent<Weapon>().Shoot();
            time = Time.time;
            Debug.Log(time);
        }
    }
}
