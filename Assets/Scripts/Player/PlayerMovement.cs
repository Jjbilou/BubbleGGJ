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

    void Update()
    {
        float xInput = Input.GetKey(keyRight)
            ? (Input.GetKey(keyLeft) ? 0.0f : 1.0f)
            : (Input.GetKey(keyLeft) ? -1.0f : 0.0f);
        float yInput = Input.GetKey(keyUp)
            ? (Input.GetKey(keyDown) ? 0.0f : 1.0f)
            : (Input.GetKey(keyDown) ? -1.0f : 0.0f);

        Vector2 movement = new(xInput, yInput);
        movement.Normalize();

        player.velocity = speed * Time.deltaTime * movement;
    }
}
