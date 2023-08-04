using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Bullet : MonoBehaviour
{
    public Rigidbody2D rigid;
    float playerspeed = 8f;
    float enemyspeed = 0.5f;

    

    public void OnBullet(string _name)
    {
        //Vector3.up - 월드 좌표
        //transform.up - 비스듬하게 해놔도 앞으로 쭉감

        switch(_name)
        {
            case "Player":
                rigid.velocity = transform.up * playerspeed;
                break;

            case "Enemy":
                rigid.velocity = -transform.up * enemyspeed;
                break;
        }
        //StartCoroutine(CheckBullet(_name));
    }

    IEnumerator CheckBullet(string s = "Player")
    {
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector3 pos = transform.position;

        while (true)
        {
            yield  return new WaitForSeconds(0.1f);

            if(s.Equals("Player"))
            {
                pos = transform.position;
                if (pos.y > max.y)
                {
                    ObjectPool.instance.ReturnQueue(this, s);
                    StopCoroutine(CheckBullet());
                }
            }
            else
            {
                pos = transform.position;
                if (pos.y < min.y)
                {
                    ObjectPool.instance.ReturnQueue(this, s);
                    StopCoroutine(CheckBullet());
                }
            }
        }
    }
}
