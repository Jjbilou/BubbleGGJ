using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    PlayerMovement playerMovement;
    float duration = 0.1f;
    bool dashActif = false;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && GameData.money >= 10 && !dashActif)
        {
            GameData.money -= 10;
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
