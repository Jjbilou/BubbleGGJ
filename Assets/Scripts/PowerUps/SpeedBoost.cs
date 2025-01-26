using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    PlayerMovement playerMovement;
    float duration = 5f;
    bool boostActif = false;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && GameData.money >= 10 && !boostActif)
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
