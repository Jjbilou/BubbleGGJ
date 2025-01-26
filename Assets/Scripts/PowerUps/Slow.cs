using UnityEngine;

public class Slow : MonoBehaviour
{
    public bool isSlow = false;

    void Update()
    {
        if (isSlow)
        {
            isSlow = false;
        }

        if (GameData.usePowerups && Input.GetKeyDown(KeyCode.R) && GameData.money >= 20)
        {
            GameData.money -= 20;
            isSlow = true;
        }
    }
}
