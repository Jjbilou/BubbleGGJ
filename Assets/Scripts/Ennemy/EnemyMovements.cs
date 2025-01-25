using UnityEngine;

public class EnemyMovements : MonoBehaviour
{
    [SerializeField]
    float speed = 50.0f;

    [SerializeField]
    Sprite frontSprite;

    [SerializeField]
    Sprite backSprite;

    [SerializeField]
    Sprite rightSprite;

    [SerializeField]
    Sprite leftSprite;

    Transform target;
    Rigidbody2D enemy;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Bubble").transform;
        enemy = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Animate();
    }

    void Move()
    {
        Vector2 movement = target.position - transform.position;
        movement.Normalize();
        enemy.velocity = speed * Time.deltaTime * movement;
    }

    void Animate()
    {
        if (Mathf.Abs(enemy.velocity.y) >= Mathf.Abs(enemy.velocity.x))
        {
            if (enemy.velocity.y > 0)
            {
                spriteRenderer.sprite = backSprite;
            }
            else
            {
                spriteRenderer.sprite = frontSprite;
            }
        }
        else
        {
            if (enemy.velocity.x > 0)
            {
                spriteRenderer.sprite = rightSprite;
            }
            else if (enemy.velocity.x < 0)
            {
                spriteRenderer.sprite = leftSprite;
            }
        }
    }
}
