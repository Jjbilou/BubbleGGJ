using UnityEngine;

public class BubbleSkin : MonoBehaviour
{
    [SerializeField]
    Sprite Bubble1;

    [SerializeField]
    Sprite Bubble2;

    [SerializeField]
    Sprite Bubble3;

    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        string skinName = PlayerPrefs.GetString("bubble", "Bubble1");

        spriteRenderer.sprite = skinName switch
        {
            "Bubble1" => Bubble1,
            "Bubble2" => Bubble2,
            "Bubble3" => Bubble3,
            _ => Bubble1,
        };
    }
}
