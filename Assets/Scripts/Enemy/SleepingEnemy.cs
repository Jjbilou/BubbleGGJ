using UnityEngine;

public class SleepingEnemy : MonoBehaviour
{
    [SerializeField]
    public float speed = 25.0f;

    [SerializeField]
    Sprite frontSprite;

    [SerializeField]
    Sprite backSprite;

    [SerializeField]
    Sprite rightSprite;

    [SerializeField]
    Sprite leftSprite;
    bool isSleeping;
    Transform target;
    GameObject player;
    Slow slow;
    Rigidbody2D enemy;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        isSleeping = false;
        target = GameObject.Find("Bubble").transform;
        player = GameObject.Find("Player");
        enemy = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        slow = player.GetComponent<Slow>();
        StartCoroutine(Sleep());
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Animate();
        if (slow.isSlow)
        {
            speed /= 2;
        }
    }

    void Move()
    {
        if (!isSleeping) {
            Vector2 movement = target.position - transform.position;
            movement.Normalize();
            enemy.velocity = speed * Time.deltaTime * movement;
        }
        else
        {
            enemy.velocity = Vector2.zero;
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

    IEnumerator Sleep()
    {
        yield return new WaitForSeconds(5);

        isSleeping = true;
    }
}
