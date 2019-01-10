using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static bool controlsType = false;
    public float PlayerSpeed = 0.2f;
    public float rotationSpeed = 2f;

    private void Start()
    {
        AsteroidSpawner.Instance.RegisterPlayer(gameObject);
    }

    void OnDestroy()
    {
        AsteroidSpawner.Instance.UnregisterPlayer(gameObject);
    }

    void FixedUpdate()
    {
        if (controlsType)
            MoveShipWithPhysicsKeyboard();
        else
            MoveShipWIthPhysicsMouse();
    }

    private void Update()
    {
        UpdateShootInputs();
    }

    private void UpdateShootInputs()
    {
        if (Input.GetButton("Weapon1"))
        {
            transform.Find("Laser").GetComponent<Weapon>().Shoot();
        }
        else if(Input.GetButtonDown("Weapon2"))
        {
            transform.Find("RocketLauncher").GetComponent<Weapon>().Shoot();
        }
    }

    private void MoveShipWithPhysicsKeyboard()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        Quaternion newRotation = transform.rotation;
        Rigidbody rb = GetComponent<Rigidbody>();
        if (horizontalInput != 0)
        {
            newRotation = Quaternion.Euler(new Vector3(0, horizontalInput * rotationSpeed, 0)); ;
            rb.MoveRotation(rb.rotation * newRotation);
        }

        Vector3 direction = new Vector3(0, 0, verticalInput);
        direction = transform.rotation * direction;
        direction = direction * PlayerSpeed * Time.deltaTime;

        rb.MovePosition(transform.position + direction);

    }

    private void MoveShipWIthPhysicsMouse()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        float playerCameraOffset = Camera.main.transform.position.y - transform.position.y;
        Vector3 mousePositionScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, playerCameraOffset);
        Vector3 mousePositionWorldSpace = Camera.main.ScreenToWorldPoint(mousePositionScreenSpace);

        Quaternion newRotation = Quaternion.LookRotation(mousePositionWorldSpace - transform.position);
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        direction = transform.rotation * direction;
        direction = direction * PlayerSpeed * Time.deltaTime;

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.MovePosition(transform.position + direction);
        rb.MoveRotation(newRotation);
    }

    
}