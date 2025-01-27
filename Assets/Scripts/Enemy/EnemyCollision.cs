using System;
using System.Collections;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField]
    int moneyDrop;
    AudioSource slash;

    private SpriteRenderer spriteRendererEnemy;
    private SpriteRenderer spriteRendererSword;
    private Transform player;
    private Transform bubble;
    private Transform swordSwipe;
    private Collider2D enemyCollider;

    bool isJudoka;

    readonly float pushForce = 1f;
    readonly float swordMoveDistance = 0.5f;

    void Start()
    {
        bubble = GameObject.Find("Bubble").transform;
        spriteRendererEnemy = GetComponent<SpriteRenderer>();
        enemyCollider = GetComponent<Collider2D>();
        isJudoka = GetComponent<JudokaEnemyMovements>() ? true : false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.transform;
            swordSwipe = player.Find("SwordSwipe").transform;
            spriteRendererSword = swordSwipe.GetComponent<SpriteRenderer>();
            slash = swordSwipe.GetComponent<AudioSource>();

            if (isJudoka)
            {
                Vector2 toBubble = bubble.position - transform.position;
                Vector2 orientation = (
                    Mathf.Abs(toBubble.x) > Mathf.Abs(toBubble.y)
                        ? (toBubble.x > 0.0f ? Vector2.right : Vector2.left)
                        : (toBubble.y > 0.0f ? Vector2.up : Vector2.down)
                ).normalized;
                Vector2 toPlayer = (player.position - transform.position).normalized;

                float dotProduct = Vector2.Dot(orientation, toPlayer);

                if (dotProduct < -0.85f)
                {
                    if (collision.gameObject.name == "Player")
                    {
                        GameData.enemyKilled++;
                    }
                    else
                    {
                        GameData.enemyKilledByP2++;
                    }

                    StartCoroutine(SwordAttack());
                }
                else
                {
                    player.position += pushForce * (Vector3)toPlayer;
                }
            }
            else
            {
                if (collision.gameObject.name == "Player")
                {
                    GameData.enemyKilled++;
                }
                else
                {
                    GameData.enemyKilledByP2++;
                }

                StartCoroutine(SwordAttack());
            }
        }
        else if (collision.gameObject.CompareTag("EnemyKiller"))
        {
            GameData.usePowerups = true;
            Destroy(gameObject);
        }
        else if (collision.gameObject.name == "Bubble")
        {
            collision.gameObject.GetComponent<BubbleCollision>().EndGame();
        }
    }

    IEnumerator SwordAttack()
    {
        slash.Play();
        swordSwipe.localPosition = Vector3.zero;

        Vector3 direction = transform.position - swordSwipe.position;
        swordSwipe.right = direction;

        Vector3 moveDirection = direction.normalized;
        swordSwipe.localPosition = swordMoveDistance * moveDirection;

        spriteRendererEnemy.enabled = false;
        enemyCollider.enabled = false;

        spriteRendererSword.enabled = true;

        yield return new WaitForSeconds(0.1f);

        spriteRendererSword.enabled = false;
        GameData.money += moneyDrop;

        GameData.usePowerups = true;

        Destroy(gameObject);
    }
}
