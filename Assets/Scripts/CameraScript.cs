using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    Vector3 playerPos, cameraPos;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //playerPos = new Vector3(Player.transform.position.x - 0.24f, Player.transform.position.y + 12.37f, Player.transform.position.z - 11.14f);
        playerPos = new Vector3(Player.transform.position.x - 0.24f, Player.transform.position.y + 12.37f, Player.transform.position.z - 11.14f);
        //cameraPos = playerPos;
        transform.position = playerPos;
    }
}
