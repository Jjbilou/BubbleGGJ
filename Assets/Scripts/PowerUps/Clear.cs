using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clear : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && GameData.money >= 100)
        {
            GameData.money -= 100;
            GameObject[] clones = GameObject.FindGameObjectsWithTag("Clone");

            foreach (GameObject clone in clones)
            {
                Destroy(clone);
            }
        }
    }
}
