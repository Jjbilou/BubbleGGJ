using TMPro;
using UnityEngine;

public class Money : MonoBehaviour
{
    TMP_Text textField;

    // Start is called before the first frame update
    void Start()
    {
        textField = GetComponent<TMP_Text>();
    }

    void Update()
    {
        textField.text = GameData.money.ToString();
    }
}
