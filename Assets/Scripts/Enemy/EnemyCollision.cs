using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField]
    int moneyDrop;

    public Coroutine gameCoroutine;

    private SpriteRenderer spriteRendererSword;
    private SpriteRenderer spriteRendererEnemy;
    private Transform swordSwipe;
    private Collider2D body;
    private bool isGameEnd;

    readonly float swordMoveDistance = 0.5f;

    void Start()
    {
        swordSwipe = GameObject.Find("SwordSwipe").transform;
        spriteRendererSword = swordSwipe.GetComponent<SpriteRenderer>();
        spriteRendererEnemy = GetComponent<SpriteRenderer>();
        body = GetComponent<Collider2D>();
        isGameEnd = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isGameEnd)
        {
            StartCoroutine(SwordAttack());
            GameData.money += moneyDrop;
        }
        else if (collision.gameObject.CompareTag("EnemyKiller"))
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.name == "Bubble")
        {
            isGameEnd = true;
            StartCoroutine(EndGame());
        }
    }

    IEnumerator SwordAttack()
    {
        swordSwipe.localPosition = Vector3.zero;

        Vector3 direction = transform.position - swordSwipe.position;
        swordSwipe.right = direction;

        Vector3 moveDirection = direction.normalized;
        swordSwipe.localPosition = swordMoveDistance * moveDirection;

        spriteRendererEnemy.enabled = false;
        body.enabled = false;

        spriteRendererSword.enabled = true;

        yield return new WaitForSeconds(0.1f);

        spriteRendererSword.enabled = false;
        Destroy(gameObject);
    }

    IEnumerator EndGame()
    {
        StopCoroutine(gameCoroutine);
        StopCoroutine(GameObject.Find("GameLogic").GetComponent<Init>().scoreCoroutine);

        GameObject[] clones = GameObject.FindGameObjectsWithTag("Clone");
        foreach (GameObject clone in clones)
        {
            clone.GetComponent<SpriteRenderer>().enabled = false;
            clone.GetComponent<Collider2D>().enabled = false;
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
