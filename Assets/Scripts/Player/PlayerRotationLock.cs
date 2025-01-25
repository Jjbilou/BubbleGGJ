using UnityEngine;

public class PlayerRotationLock : MonoBehaviour
{
    Quaternion defaultRotation;

    void Start()
    {
        defaultRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = defaultRotation;
    }
}
