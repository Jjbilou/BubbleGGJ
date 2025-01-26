using UnityEngine;

public class Player1Movement : MonoBehaviour
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
        float xInput = Input.GetKey(KeyCode.D)
            ? (Input.GetKey(KeyCode.Q) ? 0.0f : 1.0f)
            : (Input.GetKey(KeyCode.Q) ? -1.0f : 0.0f);
        float yInput = Input.GetKey(KeyCode.Z)
            ? (Input.GetKey(KeyCode.S) ? 0.0f : 1.0f)
            : (Input.GetKey(KeyCode.S) ? -1.0f : 0.0f);

        Vector2 movement = new(xInput, yInput);
        movement.Normalize();

        player.velocity = speed * Time.deltaTime * movement;
    }
}
