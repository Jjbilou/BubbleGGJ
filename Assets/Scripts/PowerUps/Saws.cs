using UnityEngine;

public class Saws : MonoBehaviour
{
    [SerializeField]
    float speed = 50.0f;
    SpriteRenderer[] renderers;
    Collider2D[] colliders;
    float sawDuration;

    // Start is called before the first frame update
    void Start()
    {
        renderers = GetComponentsInChildren<SpriteRenderer>();
        colliders = GetComponentsInChildren<Collider2D>();

        sawDuration = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameData.usePowerups && Input.GetKeyDown(KeyCode.E) && GameData.money >= 10)
        {
            GameData.money -= 10;
            sawDuration += 5.0f;
        }

        SetVisible(sawDuration > 0.0f);

        float rotationForce = speed * Time.deltaTime;
        transform.Rotate(new Vector3(0.0f, 0.0f, rotationForce));

        sawDuration = Mathf.Max(0.0f, sawDuration - Time.deltaTime);
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
