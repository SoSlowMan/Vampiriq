using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody myRB;
    public float moveSpeed;
    public PlayerController thePlayer;
    public Player2DummyScript thePlayer2;
    public int choosePlayer;
    public Player2Enabler isPlayer2On;

    public int health;
    private int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        choosePlayer = Random.Range(0, 2);
        myRB = GetComponent<Rigidbody>();
        thePlayer = FindObjectOfType<PlayerController>();
        isPlayer2On = FindObjectOfType<Player2Enabler>();
        currentHealth = health;
    }

    void FixedUpdate()
    {
        myRB.velocity = (transform.forward * moveSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if ((isPlayer2On.player2IsHere == true) && choosePlayer == 1)
        {
            thePlayer2 = FindObjectOfType<Player2DummyScript>();
            transform.LookAt(thePlayer2.transform.position);
        }
        else
        {
            //choosePlayer = 0;
            transform.LookAt(thePlayer.transform.position);
        }

        if (currentHealth <= 0)
        {
            EnemySpawnerScript.instance.enemyKilled++;
            Destroy(gameObject);

        }
    }

    public void HurtEnemy(int damage)
    {
        currentHealth -= damage;
    }

}
