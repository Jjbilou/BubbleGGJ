using UnityEngine;

public class EnnemyCollision : MonoBehaviour
{
    [SerializeField]
    int moneyDrop;

    public Coroutine gameCoroutine;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            GameData.money += moneyDrop;
            Destroy(gameObject);
        }
        else if (collision.gameObject.name == "Bubble")
        {
            StopCoroutine(gameCoroutine);
            StopCoroutine(GameObject.Find("GameLogic").GetComponent<Init>().scoreCoroutine);

            GameObject[] clones = GameObject.FindGameObjectsWithTag("clone");
            foreach (GameObject clone in clones)
            {
                Destroy(clone);
            }

            int bestScore = PlayerPrefs.GetInt("BestScore", 0);
            if (bestScore < GameData.score)
            {
                PlayerPrefs.SetInt("BestScore", GameData.score);
            }
        }
    }
}
