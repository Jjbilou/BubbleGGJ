using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    [SerializeField]
    float speed = 300.0f;

    Rigidbody2D player;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float xInput = Input.GetKey(KeyCode.RightArrow)
            ? (Input.GetKey(KeyCode.LeftArrow) ? 0.0f : 1.0f)
            : (Input.GetKey(KeyCode.LeftArrow) ? -1.0f : 0.0f);
        float yInput = Input.GetKey(KeyCode.UpArrow)
            ? (Input.GetKey(KeyCode.DownArrow) ? 0.0f : 1.0f)
            : (Input.GetKey(KeyCode.DownArrow) ? -1.0f : 0.0f);

        Vector2 movement = new(xInput, yInput);
        movement.Normalize();

        player.velocity = speed * Time.deltaTime * movement;
    }
}
