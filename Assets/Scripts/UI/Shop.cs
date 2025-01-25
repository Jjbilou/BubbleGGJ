using UnityEngine;

public class Shop : MonoBehaviour
{
    Canvas canvas;

    void Start()
    {
        canvas = GetComponent<Canvas>();
    }

    void Update()
    {
        canvas.enabled = GameData.isShopOpen;
    }

    public void BuySawDuration()
    {
        if (GameData.money >= 10)
        {
            GameData.money -= 10;
            GameData.sawDuration += 5.0f;
        }
    }
}
