using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Bullet
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ObjectPool.instance.ReturnQueue(this, "Player");
    }
}
