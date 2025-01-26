using System.Collections;
using UnityEngine;

public class TeleportingEnemyMovements : MonoBehaviour
{
    [SerializeField]
    float speed = 100.0f;

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
    Collider2D enemyCollider;

    bool isMoving;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Bubble").transform;
        enemy = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemyCollider = GetComponent<Collider2D>();

        isMoving = false;

        StartCoroutine(Teleport());
    }

    // Update is called once per frame
    void Update()
    {
        Animate();
        Move();
    }

    void Move()
    {
        if (isMoving)
        {
            Vector2 movement = target.position - transform.position;
            movement.Normalize();
            enemy.velocity = 3.0f * speed * Time.deltaTime * movement;
        }
        else
        {
            enemy.velocity = Vector2.zero;
        }
    }

    IEnumerator Teleport()
    {
        while (true)
        {
            yield return new WaitForSeconds(4.0f);

            while (spriteRenderer.color.a > 0.0f)
            {
                spriteRenderer.color = new Color(
                    spriteRenderer.color.r,
                    spriteRenderer.color.g,
                    spriteRenderer.color.b,
                    Mathf.Max(spriteRenderer.color.a - 0.05f, 0.0f)
                );

                yield return null;
            }

            enemyCollider.enabled = false;
            isMoving = true;

            yield return new WaitForSeconds(1.0f);

            isMoving = false;
            enemyCollider.enabled = true;

            while (spriteRenderer.color.a < 1.0f)
            {
                spriteRenderer.color = new Color(
                    spriteRenderer.color.r,
                    spriteRenderer.color.g,
                    spriteRenderer.color.b,
                    Mathf.Min(spriteRenderer.color.a + 0.05f, 1.0f)
                );

                yield return null;
            }
        }
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
