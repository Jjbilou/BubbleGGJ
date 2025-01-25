using UnityEngine;

public class LockRotation : MonoBehaviour
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
