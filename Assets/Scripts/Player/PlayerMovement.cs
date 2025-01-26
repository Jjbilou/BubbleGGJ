using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    KeyCode keyUp;

    [SerializeField]
    KeyCode keyLeft;

    [SerializeField]
    KeyCode keyDown;

    [SerializeField]
    KeyCode keyRight;

    public float speed = 300.0f;

    Rigidbody2D player;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float xInput = 0.0f;
        float yInput = 0.0f;

        if (Input.GetKey(keyRight))
            xInput += 1.0f;
        if (Input.GetKey(keyLeft))
            xInput -= 1.0f;

        if (Input.GetKey(keyUp))
            yInput += 1.0f;
        if (Input.GetKey(keyDown))
            yInput -= 1.0f;

        Vector2 movement = new(xInput, yInput);
        movement.Normalize();

        player.velocity = speed * Time.deltaTime * movement;
    }
}
