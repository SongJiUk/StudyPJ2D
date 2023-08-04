using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryArea : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var obj = collision.GetComponent<Bullet>();
        ObjectPool.instance.ReturnQueue(obj, collision.name);
    }
}
