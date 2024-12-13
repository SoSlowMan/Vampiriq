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
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        EnemySpawner();
        EnemyCounter();
    }

    void EnemyCounter()
    {
        if (enemyKilled == enemyCount + 1)
        {
            portal.SetActive(true);
        }
    }

    void EnemySpawner()
    {
        if (doneSpawning == false)
        {
            for (int i = 0; i <= enemyCount; i++)
            {
                EnemyController newEnemy = Instantiate(enemy, spawner.position, spawner.rotation);
                if (i == enemyCount)
                {
                    doneSpawning = true;
                }
            }
        }
    }

    void Init()
    {
        enemyCount = Random.Range(1, 7);
        enemyKilled = 0;
        doneSpawning = false;
    }

    public void KillIncrement()
    {
        enemyKilled++;
    }
}
