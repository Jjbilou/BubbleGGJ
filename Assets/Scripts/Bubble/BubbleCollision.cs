using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BubbleCollision : MonoBehaviour
{

    public Coroutine gameCoroutine;

    public void EndGame()
    {
        StartCoroutine(EndGameCoroutine());
    }

    IEnumerator EndGameCoroutine()
    {
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
