using UnityEngine;

public class EnnemyMovements : MonoBehaviour
{
    [SerializeField]
    float speed = 50.0f;

    Transform target;
    Rigidbody2D ennemy;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Bubble").transform;
        ennemy = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.up = target.position - transform.position;

        Vector2 movement = target.position - transform.position;
        movement.Normalize();
        ennemy.velocity = speed * Time.deltaTime * movement;
    }
}
