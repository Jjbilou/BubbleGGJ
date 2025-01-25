using System.Collections;
using UnityEngine;

public class ChargingEnnemyMovements : MonoBehaviour
{
    [SerializeField]
    float speed = 50.0f;

    Transform target;
    Rigidbody2D ennemy;
    bool isWaiting;
    bool isCharging;

    readonly float xRadius = 8.9f;
    readonly float yRadius = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Bubble").transform;
        ennemy = GetComponent<Rigidbody2D>();
        isWaiting = false;
        isCharging = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.up = target.position - transform.position;

        if (!isWaiting)
        {
            if (
                !isCharging
                && transform.position.x > -xRadius
                && transform.position.x < xRadius
                && transform.position.y > -yRadius
                && transform.position.y < yRadius
            )
            {
                isWaiting = true;
                StartCoroutine(WaitAndCharge());
            }

            Vector2 movement = target.position - transform.position;
            movement.Normalize();

            ennemy.velocity = (isCharging ? 5.0f : 1.0f) * speed * Time.deltaTime * movement;
        }
        else
        {
            ennemy.velocity = Vector2.zero;
        }
    }

    IEnumerator WaitAndCharge()
    {
        yield return new WaitForSeconds(5.0f);

        isWaiting = false;
        isCharging = true;
    }
}
