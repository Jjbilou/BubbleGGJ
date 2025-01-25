using System.Collections;
using System.Collections.Generic;
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

    Rigidbody2D rigidbody;
    SpriteRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        renderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rigidbody.velocity.y > 0)
        {
            renderer.sprite = backSprite;
        }
        else if (rigidbody.velocity.y < 0)
        {
            renderer.sprite = frontSprite;
        }
        else if (rigidbody.velocity.x > 0)
        {
            renderer.sprite = rightSprite;
        }
        else if (rigidbody.velocity.x < 0)
        {
            renderer.sprite = leftSprite;
        }
        else
        {
            renderer.sprite = frontSprite;
        }
    }
}
