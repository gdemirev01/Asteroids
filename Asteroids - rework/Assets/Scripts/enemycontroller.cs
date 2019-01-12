using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemycontroller : MonoBehaviour {
    public GameObject player;
    float step;
    public float speed;
    float time;
    public float speedOfFire;
    Rigidbody rb;
    public Vector3 InitialDirection = Vector3.zero;
    // Use this for initialization

    private void Start()
    {
        player = GameObject.Find("TUES_PlayerShip");
        Vector3 direction3d = InitialDirection;
        if (direction3d.sqrMagnitude < Mathf.Epsilon * Mathf.Epsilon)
        {

            Vector2 direction2d = Random.insideUnitCircle;
            direction2d.Normalize();
            direction3d = new Vector3(direction2d.x, 0, direction2d.y);
        }

        var rb = GetComponent<Rigidbody>();
        rb.velocity = direction3d * speed;
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
        transform.LookAt(player.transform);
    }

    void Shoot()
    {
        if (Time.time > time + speedOfFire)
        {
            transform.Find("Weapon").GetComponent<Weapon>().Shoot();
            time = Time.time;
            Debug.Log(time);
        }
    }
}
