using System.Collections;
using TMPro;
using UnityEngine;

public class CountScore : MonoBehaviour
{
    [SerializeField]
    float scoreAddingInterval = 2.0f;

    public Coroutine scoreCoroutine;
    public int score;

    TMP_Text textField;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        textField = GetComponent<TMP_Text>();

        scoreCoroutine = StartCoroutine(AddScore());
    }

    IEnumerator AddScore()
    {
        while (true)
        {
            yield return new WaitForSeconds(scoreAddingInterval);

            score++;
            textField.text = "Score: " + score.ToString();
        }
    }
}
