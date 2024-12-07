using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;

    public int bulletDamage;

    public int bulletColor;

    public Renderer bulletRenderer;

    //public SphereCollider collider;

    // public GameObject heart;
    public Material material0, material1, material2, material3, material4, material5, material6;//, color2;

    // Start is called before the first frame update
    void Start()
    {
        bulletColor = Random.Range(0,6);
        bulletRenderer = GetComponent<Renderer>();
        switch (bulletColor)
        {
            case 0:
                bulletRenderer.material = material0;
                break;
            case 1:
                bulletRenderer.material = material1;
                break;
            case 2:
                bulletRenderer.material = material2;
                break;
            case 3:
                bulletRenderer.material = material3;
                break;
            case 4:
                bulletRenderer.material = material4;
                break;
            case 5:
                bulletRenderer.material = material5;
                break;
            case 6:
                bulletRenderer.material = material6;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed);
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            //collider.isTrigger = false;
            other.gameObject.GetComponent<EnemyController>().HurtEnemy(bulletDamage);
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Player")
        {
            //collider.isTrigger = true;
        }
    }
}
