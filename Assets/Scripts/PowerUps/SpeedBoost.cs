using System.Collections;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    bool boostActif;

    readonly float duration = 5f;

    void Start()
    {
        boostActif = false;
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
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            player.GetComponent<PlayerMovement>().speed *= 2.0f;
        }

        yield return new WaitForSeconds(duration);

        foreach (GameObject player in players)
        {
            player.GetComponent<PlayerMovement>().speed /= 2.0f;
        }
        boostActif = false;
    }
}
