using UnityEngine;

public class EnnemyCollision : MonoBehaviour
{
    public Coroutine gameCoroutine;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.name == "Bubble")
        {
            StopCoroutine(gameCoroutine);

            CountScore countScore = GameObject.Find("Score").GetComponent<CountScore>();
            StopCoroutine(countScore.scoreCoroutine);

            int bestScore = PlayerPrefs.GetInt("BestScore", 0);
            if (bestScore < countScore.score)
            {
                PlayerPrefs.SetInt("BestScore", countScore.score);
            }
        }
    }
}
