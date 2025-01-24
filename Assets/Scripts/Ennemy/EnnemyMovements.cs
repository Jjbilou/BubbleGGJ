using UnityEngine;

public class EnnemyMovements : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float speed = 50.0f;

    Rigidbody2D ennemy;


    // Start is called before the first frame update
    void Start()
    {
        ennemy = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.up = target.position - transform.position;

        Vector2 movement = target.position - transform.position;
        ennemy.velocity = speed * Time.deltaTime * movement;
    }
}
