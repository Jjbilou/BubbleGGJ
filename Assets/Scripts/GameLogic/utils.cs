using UnityEngine;

public class Helpers : MonoBehaviour
{
    public static Vector3 GetRandomPositionOutside(float xRadius, float yRadius)
    {
        int cases = Mathf.FloorToInt(Random.Range(0, 4));

        Vector3 position = cases switch
        {
            // appears left
            0 => new Vector3(-xRadius, Random.Range(-yRadius, yRadius), 0.0f),
            // appears right
            1 => new Vector3(xRadius, Random.Range(-yRadius, yRadius), 0.0f),
            // appears bottom
            2 => new Vector3(Random.Range(-xRadius, xRadius), -yRadius, 0.0f),
            // appears top
            3 => new Vector3(Random.Range(-xRadius, xRadius), yRadius, 0.0f),
            _ => new Vector3(xRadius, yRadius, 0.0f),
        };

        return position;
    }

    public static Object GetRandomObject(Object triangle, Object chargingTriangle)
    {
        int cases = Mathf.FloorToInt(Random.Range(0, 2));

        Object ennemy = cases switch
        {
            0 => triangle,
            1 => chargingTriangle,
            _ => triangle,
        };

        return ennemy;
    }
}
