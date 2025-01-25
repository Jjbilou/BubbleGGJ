using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Init : MonoBehaviour
{
    [SerializeField]
    float scoreAddingInterval = 2.0f;

    public Coroutine scoreCoroutine;

    void Awake()
    {
        SceneManager.LoadScene("GameUI", LoadSceneMode.Additive);
    }

    void Start()
    {
        scoreCoroutine = StartCoroutine(AddScore());
    }

    IEnumerator AddScore()
    {
        while (true)
        {
            yield return new WaitForSeconds(scoreAddingInterval);

            GameData.score++;
        }
    }
}
