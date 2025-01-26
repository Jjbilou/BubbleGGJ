using System.Collections;
using UnityEngine;

public class Dash : MonoBehaviour
{
    PlayerMovement playerMovement;
    bool dashActif = false;

    readonly float duration = 0.1f;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (
            GameData.usePowerups
            && Input.GetKeyDown(KeyCode.Space)
            && GameData.money >= 15
            && !dashActif
        )
        {
            GameData.money -= 15;
            StartCoroutine(Boost());
            dashActif = true;
        }
    }

    IEnumerator Boost()
    {
        playerMovement.speed += 2000f;

        yield return new WaitForSeconds(duration);

        playerMovement.speed -= 2000f;
        dashActif = false;
    }
}
