using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance = null;

    [SerializeField] Transform[] shootPos;
    float Speed = 2f;

    //Vector3 dir = Vector3.zero;
    private void Awake()
    {
        if (null == instance) instance = this;
        else Destroy(this.gameObject);
    }

    private void Start()
    {
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
            var bullet = ObjectPool.instance.GetBulletQueue();
            bullet.transform.position = shootPos[i].transform.position;
            bullet.transform.rotation = shootPos[i].transform.rotation;
            bullet.OnBullet();
        }
    }

}
