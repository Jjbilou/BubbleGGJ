using UnityEngine;

public class PlayerKeyboardMovement : MonoBehaviour
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
        Vector2 movement = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        movement.Normalize();

        player.velocity = speed * Time.deltaTime * movement;
    }
}
