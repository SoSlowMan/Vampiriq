using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody myRigidbody;

    private Vector3 moveInput;
    private Vector3 moveVelocity;

    private Camera mainCamera;

    public GunController theGun;

    public bool useController = false;

    public int health;
    public int currentHealth;

    public int enemyCount;
    public int enemyKilled;

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
        if(currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }        

        if(name == "Player")
        {
            moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
            moveVelocity = moveInput * moveSpeed;

            Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            float rayLength;

            if (groundPlane.Raycast(cameraRay, out rayLength))
            {
                Vector3 pointToLook = cameraRay.GetPoint(rayLength);
                Debug.DrawLine(cameraRay.origin, pointToLook, Color.green);

                transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
            }

            if (Input.GetMouseButtonDown(0))
            {
                theGun.isFiring = true;
            }
            if (Input.GetMouseButtonUp(0))
            {
                theGun.isFiring = false;
            }
        }

        if(name == "Player2")
        {
            moveInput = new Vector3(Input.GetAxisRaw("HorizontalJoy"), 0f, Input.GetAxisRaw("VerticalJoy"));
            moveVelocity = moveInput * moveSpeed;

            //rotate with controller
            Vector3 playerDirection = Vector3.right * Input.GetAxisRaw("RHorizontal") + Vector3.forward * -Input.GetAxisRaw("RVertical");
            if (playerDirection.sqrMagnitude > 0.0f) //check if the buttons are pushed
            {
                transform.rotation = Quaternion.LookRotation(playerDirection, Vector3.up);
            }

            if (Input.GetKeyDown(KeyCode.Joystick1Button5))
            {
                theGun.isFiring = true;
            }
            if (Input.GetKeyUp(KeyCode.Joystick1Button5))
            {
                theGun.isFiring = false;
            }
        }

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
}
