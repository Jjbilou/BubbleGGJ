using UnityEngine;
using UnityEngine.UI;

public class SetToggledBubble : MonoBehaviour
{
    [SerializeField]
    string bubbleName;

    string bubble;

    Toggle toggle;

    void Start()
    {
        toggle = GetComponent<Toggle>();
    }

    void Update()
    {
        bubble = PlayerPrefs.GetString("bubble", "Bubble1");

        toggle.isOn = bubbleName == bubble;
    }

    public void ChangeBubble()
    {
        if (toggle.isOn)
        {
            PlayerPrefs.SetString("bubble", bubbleName);
        }
    }
}
