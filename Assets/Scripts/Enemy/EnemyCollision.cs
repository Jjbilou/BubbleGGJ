using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField]
    int moneyDrop;
    AudioSource slash;

    public Coroutine gameCoroutine;

    private SpriteRenderer spriteRendererSword;
    private SpriteRenderer spriteRendererEnemy;
    private GameObject swordSwipe;
    private Collider2D body;
    private bool isGameEnd;

    void Start()
    {
        swordSwipe = GameObject.Find("SwordSwipe");
        spriteRendererSword = swordSwipe.GetComponent<SpriteRenderer>();
        slash = swordSwipe.GetComponent<AudioSource>();
        spriteRendererEnemy = GetComponent<SpriteRenderer>();
        body = GetComponent<Collider2D>();
        isGameEnd = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isGameEnd)
        {
            slash.Play();
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
        Vector3 direction = transform.position - swordSwipe.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        swordSwipe.transform.rotation = Quaternion.Euler(0, 0, angle);

        float moveDistance = 0.5f;
        Vector3 moveDirection = direction.normalized;
        swordSwipe.transform.position += moveDirection * moveDistance;

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
