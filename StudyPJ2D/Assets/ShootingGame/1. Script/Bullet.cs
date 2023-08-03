using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Bullet : MonoBehaviour
{
    public Rigidbody2D rigid;
    float speed = 4f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            ObjectPool.instance.ReturnQueue(this);
        }
    }

    public void OnBullet()
    {
        this.gameObject.SetActive(true);

        //Vector3.up - 월드 좌표
        //transform.up - 비스듬하게 해놔도 앞으로 쭉감
        rigid.velocity = transform.up * speed;
        StartCoroutine(CheckBullet());
    }

    IEnumerator CheckBullet()
    {
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Vector3 pos = transform.position;

        while (true)
        {
            yield  return new WaitForSeconds(0.1f);

            pos = transform.position;
            if (pos.y > max.y)
            {
                ObjectPool.instance.ReturnQueue(this);
                StopCoroutine(CheckBullet());
                
            }
            
        }
    }
}
