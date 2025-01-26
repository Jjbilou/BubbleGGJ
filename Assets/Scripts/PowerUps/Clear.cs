using UnityEngine;

public class Clear : MonoBehaviour
{
    void Update()
    {
        if (GameData.usePowerups && Input.GetKeyDown(KeyCode.C) && GameData.money >= 50)
        {
            GameData.money -= 50;
            GameObject[] clones = GameObject.FindGameObjectsWithTag("Clone");

            foreach (GameObject clone in clones)
            {
                Destroy(clone);
            }
        }
    }
}
