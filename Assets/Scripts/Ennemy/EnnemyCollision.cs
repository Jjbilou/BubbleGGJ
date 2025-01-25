using UnityEngine;

public class EnnemyCollision : MonoBehaviour
{
    public Coroutine gameCoroutine;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.name == "Bubble")
        {
            StopCoroutine(gameCoroutine);
        }
    }
}
