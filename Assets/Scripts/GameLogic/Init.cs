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
        GameData.money = 0;
        GameData.score = 0;
        GameData.sawDuration = 0.0f;

        scoreCoroutine = StartCoroutine(AddScore());
    }

    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Tab))
        // {
        //     GameData.isShopOpen = !GameData.isShopOpen;
        // }

        if (Input.GetKeyDown(KeyCode.A) && GameData.money >= 10)
        {
            GameData.money -= 10;
            GameData.sawDuration += 5.0f;
        }
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
