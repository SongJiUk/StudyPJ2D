using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipReset : MonoBehaviour
{
    Vector3 originalPostion;
    Quaternion originalRotation;

    private void OnEnable()
    {
        originalPostion = transform.position;
        originalRotation = transform.rotation;
    }

    private void OnDisable()
    {
        transform.position = originalPostion;
        transform.rotation = originalRotation;
    }
}
