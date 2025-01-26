using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]
    Sprite frontSprite;

    [SerializeField]
    Sprite backSprite;

    [SerializeField]
    Sprite rightSprite;

    [SerializeField]
    Sprite leftSprite;

    Rigidbody2D body;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (body.velocity.y > 0)
        {
            spriteRenderer.sprite = backSprite;
        }
        else if (body.velocity.y < 0)
        {
            spriteRenderer.sprite = frontSprite;
        }
        else if (body.velocity.x > 0)
        {
            spriteRenderer.sprite = rightSprite;
        }
        else if (body.velocity.x < 0)
        {
            spriteRenderer.sprite = leftSprite;
        }
        else
        {
            spriteRenderer.sprite = frontSprite;
        }
    }
}
