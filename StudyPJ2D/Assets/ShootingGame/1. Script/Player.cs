using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance = null;

    const int MAXBULLET = 100;
    [SerializeField] Bullet bullet;
    [SerializeField] GameObject Obj_Pool_Bullet;
    [SerializeField] Transform[] shootPos;

    Queue<Bullet> bullet_que = new Queue<Bullet>();

    float Speed = 2f;
    //Vector3 dir = Vector3.zero;
    private void Awake()
    {
        if (null == instance) instance = this;
        else Destroy(this.gameObject);
    }

    private void Start()
    {
        for (int i = 0; i < MAXBULLET; i++)
        {
            var obj = Instantiate(bullet, Obj_Pool_Bullet.transform);
            obj.gameObject.SetActive(false);
            bullet_que.Enqueue(obj);
        }

        //취소
        //CancelInvoke();
        //반복 실행 함수
        //InvokeRepeating("Fire", 0, 0.5f);
        //Invoke("dd", 2f);

    }

    void Update()
    {
        Move();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }

    public void Move()
    {
        #region Input 사용 
        //if (Input.GetKey(KeyCode.A))
        //{
        //    dir = new Vector3(-1f, 0f, 0f);
        //    transform.position += dir * Time.deltaTime * Speed;
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    dir = new Vector3(1f, 0f, 0f);
        //    transform.position += dir * Time.deltaTime * Speed;
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    dir = new Vector3(0f, -1f, 0f);
        //    transform.position += dir * Time.deltaTime * Speed;
        //}
        //if (Input.GetKey(KeyCode.W))
        //{
        //    dir = new Vector3(0f, 1f, 0f);
        //    transform.position += dir * Time.deltaTime * Speed;
        //}
        #endregion

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 diretion = new Vector2(x, y);
        diretion.Normalize();

        Vector3 pos = transform.position;

        pos += diretion * Time.deltaTime * Speed;

        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        transform.position = pos;
    }

    public void Fire()
    {

        for(int i =0; i<3; i++)
        {
            var bullet = bullet_que.Dequeue();
            bullet.transform.position = shootPos[i].transform.position;
            bullet.transform.rotation = shootPos[i].transform.rotation;
            bullet.OnBullet();
        }
    }

    public void ReturnQueue(Bullet _bullet)
    {
        _bullet.gameObject.SetActive(false);
        bullet_que.Enqueue(_bullet);
    }
}
