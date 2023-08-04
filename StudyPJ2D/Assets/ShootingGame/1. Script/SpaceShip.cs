using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    [SerializeField] protected Transform[] shootPos;
    [SerializeField] protected Animator anim;

    private int hp;
    public int HP
    {
        get;
        set;
    }

    public void Fire()
    {
        for (int i = 0; i < 3; i++)
        {
            var bullet = ObjectPool.instance.GetBulletQueue("Player");
            bullet.gameObject.SetActive(true);
            bullet.transform.position = shootPos[i].transform.position;
            bullet.transform.rotation = shootPos[i].transform.rotation;
            bullet.OnBullet("Player");
        }
    }

    public void Hit()
    {
        HP--;
        if (HP == 0)
        {
            //var ex = ObjectPool.instance.GetExplosion();
            //ex.transform.position = this.transform.position;
            //Destroy(this.gameObject);
            gameObject.SetActive(false);
        }
        else anim.SetTrigger("IsHit");
    }

}
