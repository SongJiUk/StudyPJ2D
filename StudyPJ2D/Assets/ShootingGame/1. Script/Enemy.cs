using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : SpaceShip
{
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] float Speed;
    private void OnEnable()
    {
        HP = 2;
        InvokeRepeating("Fire", 0f, 3f);
        rigid.velocity = -transform.up * Speed;
    } 

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Hit();
    }


    public void Fire()
    {
        var bullet = ObjectPool.instance.GetBulletQueue("Enemy");
        bullet.gameObject.SetActive(true);
        bullet.transform.position = shootPos[0].transform.position;
        bullet.transform.rotation = shootPos[0].transform.rotation;
        bullet.OnBullet("Enemy");
    }

    public void Boom()
    {
        //재활용
        Destroy(this.gameObject);
    }
}
