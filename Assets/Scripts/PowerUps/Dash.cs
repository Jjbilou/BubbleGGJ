using System.Collections;
using UnityEngine;

public class Dash : MonoBehaviour
{
    [SerializeField]
    KeyCode key;

    PlayerMovement playerMovement;
    bool dashActif = false;

    readonly float duration = 0.1f;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (GameData.usePowerups && Input.GetKeyDown(key) && GameData.money >= 5 && !dashActif)
        {
            GameData.money -= 5;
            StartCoroutine(Boost());
        }
    }

    IEnumerator Boost()
    {
        dashActif = true;
        playerMovement.speed += 2000f;

        yield return new WaitForSeconds(duration);

        playerMovement.speed -= 2000f;
        dashActif = false;
    }
}
