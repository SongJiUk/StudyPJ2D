using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public Transform target;
    float speed = 1f;

    private void Update()
    {
        Vector3 vec = target.position - transform.position;

        if(vec.magnitude > 2f)
        {
            vec.Normalize();
            transform.position += vec * Time.deltaTime * speed;
        }
    }
}
