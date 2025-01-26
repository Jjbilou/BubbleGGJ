using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemyMovements : MonoBehaviour
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

    [SerializeField]
    Object bullet;

    Transform target;
    Rigidbody2D enemy;
    SpriteRenderer spriteRenderer;

    bool isShooting;
    Coroutine gameCoroutine;

    void Start()
    {
        target = GameObject.Find("Bubble").transform;
        enemy = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameCoroutine = GetComponent<EnemyCollision>().gameCoroutine;

        isShooting = false;
    }

    void Update()
    {
        Animate();
        Move();
    }

    void Move()
    {
        if (!isShooting)
        {
            if (Vector2.Distance(target.position, transform.position) > 7.0f)
            {
                Vector2 movement = target.position - transform.position;
                movement.Normalize();
                enemy.velocity = speed * Time.deltaTime * movement;
            }
            else
            {
                isShooting = true;
                enemy.velocity = Vector2.zero;

                StartCoroutine(Shoot());
            }
        }
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(10.0f);

            GameObject newBullet = (GameObject)Instantiate(
                bullet,
                transform.position,
                Quaternion.identity
            );
            newBullet.tag = "Clone";
            newBullet.GetComponent<EnemyCollision>().gameCoroutine = gameCoroutine;
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