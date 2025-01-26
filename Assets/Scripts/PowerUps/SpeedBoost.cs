using System.Collections;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    PlayerMovement playerMovement;
    bool boostActif = false;

    readonly float duration = 5f;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (
            GameData.usePowerups
            && Input.GetKeyDown(KeyCode.A)
            && GameData.money >= 10
            && !boostActif
        )
        {
            GameData.money -= 10;
            StartCoroutine(Boost());
            boostActif = true;
        }
    }

    IEnumerator Boost()
    {
        playerMovement.speed += 500f;

        yield return new WaitForSeconds(duration);

        playerMovement.speed -= 500f;
        boostActif = false;
    }
}
