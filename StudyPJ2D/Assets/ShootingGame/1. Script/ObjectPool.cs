using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance = null;

    const int MAXBULLET = 100;
    [SerializeField] Bullet bullet;
    [SerializeField] GameObject Bullet_parent;
    Queue<Bullet> bullet_que = new Queue<Bullet>();

    List<GameObject>[] poolList;
 
    void Start()
    {
        if (null == instance) instance = this;
        else Destroy(this.gameObject);

        CreateBullet();
    }

    #region 총알 오브젝트 생성 및 관리

    public void CreateBullet()
    {
        for (int i = 0; i < MAXBULLET; i++)
        {
            var obj = Instantiate(bullet, Bullet_parent.transform);
            obj.gameObject.SetActive(false);
            bullet_que.Enqueue(obj);
        }
    }

    public Bullet GetBulletQueue()
    {
        return bullet_que.Dequeue();
    }

    public void ReturnQueue(Bullet _bullet)
    {
        _bullet.gameObject.SetActive(false);
        bullet_que.Enqueue(_bullet);
    }
    #endregion
}
