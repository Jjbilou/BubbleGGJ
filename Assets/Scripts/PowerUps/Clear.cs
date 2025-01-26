using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clear : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
