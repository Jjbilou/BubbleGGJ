using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    float speed = 100.0f;

    Transform target;
    Rigidbody2D enemy;

    void Start()
    {
        target = GameObject.Find("Bubble").transform;
        enemy = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized;

        transform.up = direction;
        enemy.velocity = speed * Time.deltaTime * direction;
    }
}
