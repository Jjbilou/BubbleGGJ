using TMPro;
using UnityEngine;

public class EnemyKilledByP2 : MonoBehaviour
{
    TMP_Text textField;
    bool isShown;

    void Start()
    {
        textField = GetComponent<TMP_Text>();
        isShown = GameObject.Find("Player2") ? true : false;
    }

    void Update()
    {
        if (isShown)
        {
            textField.text = "P2: " + GameData.enemyKilledByP2.ToString();
        }
        else
        {
            textField.text = "";
        }
    }
}
