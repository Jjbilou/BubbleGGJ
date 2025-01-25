using TMPro;
using UnityEngine;

public class BestScore : MonoBehaviour
{
    int bestScore;
    TMP_Text textField;

    void Start()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        textField = GetComponent<TMP_Text>();

        textField.text = "Best score: " + bestScore;
    }
}
