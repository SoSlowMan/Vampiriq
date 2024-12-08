using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] Rigidbody myRigidbody;

    private Vector3 moveInput;
    private Vector3 moveVelocity;

    [SerializeField] Camera mainCamera;

    [SerializeField] GunController theGun;

    [SerializeField] bool useController = false;

    [SerializeField] int health;
    [SerializeField] int currentHealth;

    [SerializeField] int enemyCount;
    [SerializeField] int enemyKilled;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
        currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        AmIDead();
        Move();
        Shoot();
        Rotate();
    }

    void FixedUpdate()
    {
        myRigidbody.velocity = moveVelocity;
    }

    public void PlayerHurt(int damage)
    {
        currentHealth -= damage;
        //Vector3 playerPos = new Vector3(transform.position.x - 2, transform.position.y, transform.position.z);
        //transform.position = playerPos;
    }

    void AmIDead()
    {
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    void Move()
    {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * moveSpeed;
    }

    void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            theGun.isFiring = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            theGun.isFiring = false;
        }
    }

    void Rotate()
    {
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.green);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
    }
}
