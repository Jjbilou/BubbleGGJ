using UnityEngine;

public class BubbleAnimation : MonoBehaviour
{
    float defaultScaleX;
    float defaultScaleY;
    int frameCount;

    void Start()
    {
        defaultScaleX = transform.localScale.x;
        defaultScaleY = transform.localScale.y;
        frameCount = 0;
    }

    void FixedUpdate()
    {
        transform.localScale = (frameCount % 60) switch
        {
            0 => new Vector3(defaultScaleX, defaultScaleY, 1.0f),
            3 => new Vector3(defaultScaleX, defaultScaleY * 1.02f, 1.0f),
            6 => new Vector3(defaultScaleX, defaultScaleY * 1.04f, 1.0f),
            9 => new Vector3(defaultScaleX, defaultScaleY * 1.06f, 1.0f),
            12 => new Vector3(defaultScaleX, defaultScaleY * 1.08f, 1.0f),
            15 => new Vector3(defaultScaleX, defaultScaleY * 1.1f, 1.0f),
            18 => new Vector3(defaultScaleX, defaultScaleY * 1.08f, 1.0f),
            21 => new Vector3(defaultScaleX, defaultScaleY * 1.06f, 1.0f),
            24 => new Vector3(defaultScaleX, defaultScaleY * 1.04f, 1.0f),
            27 => new Vector3(defaultScaleX, defaultScaleY * 1.02f, 1.0f),
            30 => new Vector3(defaultScaleX, defaultScaleY, 1.0f),
            33 => new Vector3(defaultScaleX, defaultScaleY * 0.98f, 1.0f),
            36 => new Vector3(defaultScaleX, defaultScaleY * 0.96f, 1.0f),
            39 => new Vector3(defaultScaleX, defaultScaleY * 0.94f, 1.0f),
            42 => new Vector3(defaultScaleX, defaultScaleY * 0.92f, 1.0f),
            45 => new Vector3(defaultScaleX, defaultScaleY * 0.9f, 1.0f),
            48 => new Vector3(defaultScaleX, defaultScaleY * 0.92f, 1.0f),
            51 => new Vector3(defaultScaleX, defaultScaleY * 0.94f, 1.0f),
            54 => new Vector3(defaultScaleX, defaultScaleY * 0.96f, 1.0f),
            57 => new Vector3(defaultScaleX, defaultScaleY * 0.98f, 1.0f),
            _ => transform.localScale,
        };

        frameCount++;
    }
}
