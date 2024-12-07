using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    public static EnemySpawnerScript instance;

    public EnemyController enemy;
    public int enemyCount;
    public int enemyKilled;
    public Transform spawner;
    //public Vector3 spawnerPos;
    public bool doneSpawning;
    public GameObject portal;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        enemyCount = Random.Range(1, 7);
        enemyKilled = 0;
        doneSpawning = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (doneSpawning == false)
        {
            Debug.Log("иф работает");
            for (int i = 0; i <= enemyCount; i++)
            {
                Debug.Log("фор работает");
                EnemyController newEnemy = Instantiate(enemy, spawner.position, spawner.rotation) as EnemyController;
                if (i == enemyCount)
                {
                    Debug.Log("иф2 работает");
                    doneSpawning = true;
                }
            }
        }

        if (enemyKilled == enemyCount+1)
        {
            portal.SetActive(true);
        }
    }
}
