using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;

    [SerializeField] int bulletDamage, bulletColor;

    [SerializeField] Renderer bulletRenderer;

    [SerializeField] Material[] materials;

    // Start is called before the first frame update
    void Start()
    {
        //Coloring();
        bulletRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyController>().HurtEnemy(bulletDamage);
            Destroy(gameObject);
        }
    }

    public void Coloring()
    {
        Material[] materials = new Material[7];
        bulletColor = Random.Range(0, 6);
        bulletRenderer.material = materials[bulletColor];
    }

    void Movement()
    {
        transform.Translate(Vector3.forward * speed);
    }
}
