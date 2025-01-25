using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField]
    int moneyDrop;

    public Coroutine gameCoroutine;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameData.money += moneyDrop;
            Destroy(gameObject);
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

    IEnumerator EndGame()
    {
        StopCoroutine(gameCoroutine);
        StopCoroutine(GameObject.Find("GameLogic").GetComponent<Init>().scoreCoroutine);

        GameObject[] clones = GameObject.FindGameObjectsWithTag("Clone");
        foreach (GameObject clone in clones)
        {
            if (clone != gameObject)
                Destroy(clone);
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
