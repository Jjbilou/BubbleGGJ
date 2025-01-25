using UnityEngine;

public class BubbleSaws : MonoBehaviour
{
    [SerializeField]
    float speed = 50.0f;
    SpriteRenderer[] renderers;
    Collider2D[] colliders;

    // Start is called before the first frame update
    void Start()
    {
        renderers = GetComponentsInChildren<SpriteRenderer>();
        colliders = GetComponentsInChildren<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        SetVisible(GameData.sawDuration > 0.0f);

        float rotationForce = speed * Time.deltaTime;
        transform.Rotate(new Vector3(0.0f, 0.0f, rotationForce));

        GameData.sawDuration = Mathf.Max(0.0f, GameData.sawDuration - Time.deltaTime);
    }

    void SetVisible(bool isVisible)
    {
        foreach (SpriteRenderer renderer in renderers)
        {
            renderer.enabled = isVisible;
        }
        foreach (Collider2D collider in colliders)
        {
            collider.enabled = isVisible;
        }
    }
}
