using UnityEngine;

public class Clear : MonoBehaviour
{
    void Update()
    {
        if (GameData.usePowerups && Input.GetKeyDown(KeyCode.C) && GameData.money >= 100)
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
