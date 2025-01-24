using UnityEngine;

public class EnnemyCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.name == "Bubble")
        {
            print("PERDU");
        }
    }
}
