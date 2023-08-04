using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance = null;

    const int MAXBULLET = 100;
    [Header("총알")]
    [SerializeField] PlayerBullet player_bullet;
    [SerializeField] EnemyBullet enemy_bullet;
    [SerializeField] GameObject Bullet_parent;

    Dictionary<string, Queue<Bullet>> bullet_Dic = new Dictionary<string, Queue<Bullet>>();
    Queue<Bullet> player_bullet_que = new Queue<Bullet>();
    Queue<Bullet> enemy_bullet_que = new Queue<Bullet>();

    [Header("폭발")]
    [SerializeField] GameObject explosion;
    [SerializeField] GameObject explosion_parent;
    

    
    [SerializeField] GameObject[] Prefabs;
    List<GameObject>[] poolobjList;

    private void Awake()
    {
        if (null == instance) instance = this;
        else Destroy(this.gameObject);

        
    }
    void Start()
    {

        CreateBullet();
        //CreateExplosion();
    }

  

    #region 총알 오브젝트 생성 및 관리

    public void CreateBullet()
    {
        for (int i = 0; i < MAXBULLET; i++)
        {
            var p_obj = Instantiate(player_bullet, Bullet_parent.transform);
            p_obj.gameObject.SetActive(false);
            p_obj.name = "Player";
            player_bullet_que.Enqueue(p_obj);

            var e_obj = Instantiate(enemy_bullet, Bullet_parent.transform);
            e_obj.gameObject.SetActive(false);
            e_obj.name = "Enemy";
            enemy_bullet_que.Enqueue(e_obj);
        }

        bullet_Dic.Add("Player", player_bullet_que);
        bullet_Dic.Add("Enemy", enemy_bullet_que);
    }

    public Bullet GetBulletQueue(string _name)
    {
        return bullet_Dic[_name].Dequeue();
    }

    public void ReturnQueue(Bullet _bullet, string _name)
    {
        _bullet.gameObject.SetActive(false);
        bullet_Dic[_name].Enqueue(_bullet);
    }
    #endregion


    #region 폭발 효과 
    public void CreateExplosion()
    {
        poolobjList = new List<GameObject>[Prefabs.Length];
        int bufferAmount = 10;
        for (int i = 0; i < Prefabs.Length; ++i)
        {
            poolobjList[i] = new List<GameObject>();
            for (int j = 0; j < bufferAmount; ++j)
            {

                GameObject obj = Instantiate(Prefabs[i]);
                obj.name = Prefabs[i].name;
                PoolObject(obj);
            }
        }
    }

    
    public void PoolObject(GameObject obj)
    {
        for (int i = 0; i < Prefabs.Length; ++i)
        {
            if (Prefabs[i].name == obj.name)
            {
                obj.transform.SetParent(this.transform);
                obj.SetActive(false);
                poolobjList[i].Add(obj);
                return;
            }
        }
    }

    public GameObject GetExplosion()
    {
        return poolobjList[0][0];
    }

    public void ReturnExplosion()
    {

    }
    #endregion
}
