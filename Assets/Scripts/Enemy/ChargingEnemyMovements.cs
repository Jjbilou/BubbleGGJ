using System.Collections;
using UnityEngine;

public class ChargingEnemyMovements : MonoBehaviour
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

    bool isWaiting;
    bool isCharging;

    readonly float xRadius = 17f;
    readonly float yRadius = 9.5f;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Bubble").transform;
        enemy = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        isWaiting = false;
        isCharging = false;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Animate();
    }

    IEnumerator WaitAndCharge()
    {
        yield return new WaitForSeconds(3.0f);

        isWaiting = false;
        isCharging = true;
    }

    void Move()
    {
        Vector2 movement = target.position - transform.position;
        movement.Normalize();

        if (!isWaiting)
        {
            if (
                !isCharging
                && transform.position.x > -xRadius
                && transform.position.x < xRadius
                && transform.position.y > -yRadius
                && transform.position.y < yRadius
            )
            {
                isWaiting = true;
                StartCoroutine(WaitAndCharge());
            }

            enemy.velocity = (isCharging ? 5.0f : 1.0f) * speed * Time.deltaTime * movement;
        }
        else
        {
            enemy.velocity = 0.1f * speed * Time.deltaTime * movement;
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
