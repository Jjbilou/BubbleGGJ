using System.Collections;
using UnityEngine;

public class HidingEnemyMovement : MonoBehaviour
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
    Slow slow;
    GameObject player;
    SpriteRenderer spriteRenderer;

    bool isWaiting;
    bool isWalking;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        target = GameObject.Find("Bubble").transform;
        enemy = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        isWaiting = false;
        isWalking = false;

        if (player)
        {
            slow = player.GetComponent<Slow>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Animate();
        if (slow && slow.isSlow)
        {
            speed /= 2;
        }
    }

    IEnumerator WaitAndShow()
    {
        while (spriteRenderer.color.a != 1.0f)
        {
            spriteRenderer.color = new Color(
                spriteRenderer.color.r,
                spriteRenderer.color.g,
                spriteRenderer.color.b,
                Mathf.Min(spriteRenderer.color.a + 0.05f, 1.0f)
            );

            yield return null;
        }

        yield return new WaitForSeconds(0.5f);

        isWaiting = false;
        isWalking = true;
    }

    void Move()
    {
        Vector2 movement = target.position - transform.position;
        movement.Normalize();

        if (!isWaiting)
        {
            if (!isWalking && Vector2.Distance(transform.position, target.position) <= 4.0f)
            {
                isWaiting = true;
                StartCoroutine(WaitAndShow());
            }

            enemy.velocity = (isWalking ? 1.0f : 5.0f) * speed * Time.deltaTime * movement;
        }
        else
        {
            enemy.velocity = Vector3.zero;
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
