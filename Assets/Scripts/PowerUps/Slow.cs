using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow : MonoBehaviour
{
    public bool isSlow = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isSlow)
        {
            isSlow = false;
        }

        if (Input.GetKeyDown(KeyCode.R) && GameData.money >= 50)
        {
            GameData.money -= 50;
            isSlow = true;
        }
    }
}
