using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public static Explosion instance = null;
    private void Awake()
    {
        if (null == instance) instance = this;
        else Destroy(this.gameObject);
    }

    public void Die()
    {
        ObjectPool.instance.ReturnExplosion();
    }
   
}
