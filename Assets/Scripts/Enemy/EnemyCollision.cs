using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField]
    int moneyDrop;
    AudioSource slash;

    public Coroutine gameCoroutine;

    private SpriteRenderer spriteRendererEnemy;
    private SpriteRenderer spriteRendererSword;
    private Transform player;
    private Transform bubble;
    private Transform swordSwipe;
    private Collider2D enemyCollider;
    private bool isGameEnd;

    bool isJudoka;
    float pushForce;

    readonly float swordMoveDistance = 0.5f;

    void Start()
    {
        player = GameObject.Find("Player").transform;
        swordSwipe = player.Find("SwordSwipe").transform;
        bubble = GameObject.Find("Bubble").transform;
        spriteRendererSword = swordSwipe.GetComponent<SpriteRenderer>();
        slash = swordSwipe.GetComponent<AudioSource>();
        spriteRendererEnemy = GetComponent<SpriteRenderer>();
        enemyCollider = GetComponent<Collider2D>();
        isGameEnd = false;
        isJudoka = GetComponent<JudokaEnemyMovements>() ? true : false;
        pushForce = 0.5f;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isGameEnd)
        {
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

                if (dotProduct < 0)
                {
                    StartCoroutine(SwordAttack());
                }
                else
                {
                    player.position += pushForce * (Vector3)toPlayer;
                }
            }
            else
            {
                StartCoroutine(SwordAttack());
            }
        }
        else if (collision.gameObject.CompareTag("EnemyKiller"))
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.name == "Bubble")
        {
            StartCoroutine(EndGame());
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

        Destroy(gameObject);
    }

    IEnumerator EndGame()
    {
        isGameEnd = true;

        StopCoroutine(gameCoroutine);

        GameObject[] clones = GameObject.FindGameObjectsWithTag("Clone");
        foreach (GameObject clone in clones)
        {
            if (clone == gameObject)
            {
                clone.GetComponent<SpriteRenderer>().enabled = false;
                clone.GetComponent<Collider2D>().enabled = false;
            }
            else
            {
                Destroy(clone);
            }
        }

        int bestScore = PlayerPrefs.GetInt("BestScore", 0);
        if (bestScore < GameData.score)
        {
            PlayerPrefs.SetInt("BestScore", GameData.score);
        }

        yield return new WaitForSeconds(3.0f);

        SceneManager.LoadScene("MainMenu");
    }
}
