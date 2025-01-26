using TMPro;
using UnityEngine;

public class EnemyKilled : MonoBehaviour
{
    TMP_Text textField;
    bool isShown;

    // Start is called before the first frame update
    void Start()
    {
        textField = GetComponent<TMP_Text>();
        isShown = GameObject.Find("Player2") ? true : false;
    }

    void Update()
    {  
        if (isShown)
        {
            textField.text = "P1: " + GameData.enemyKilled.ToString();
        }
        else
        {
            textField.text = "";
        }
    }
}
