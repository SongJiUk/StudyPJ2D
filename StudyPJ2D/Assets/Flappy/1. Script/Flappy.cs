using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flappy : MonoBehaviour
{

    public Rigidbody2D rigid;
    public Animator anim;
    float forwardSpeed = 3f;
    float defaultRotate;


    public BoxCollider2D[] boxCollider;

    void Start()
    {

        rigid = GetComponent<Rigidbody2D>();
        //if (rigid != null)  rigid.velocity = new Vector2(forwardSpeed, 0);
        defaultRotate = rigid.rotation;

    }

    float velocity = 0;
    bool keydown = false;


    void Update()
    {

        //��� 1 
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    velocity = 0;
        //}
        //velocity += Time.deltaTime * 0.02f;
        //transform.position += new Vector3(0f, 0.1f - velocity, 0f);

        //���2
        //velocity += Time.deltaTime * 2f;
        //transform.position += new Vector3(0f, Mathf.Sin(velocity) * Time.deltaTime, 0f);

        //AABB ( ���� ���ĵǾ������� )
        // OOB


        //getkeydown ����
        //if (Input.anyKey)
        //{
        //    if(keydown == false)
        //    {
        //        keydown = true;
        //        rigid.AddForce(Vector2.up * 200f);
        //    }
        //}
        //else keydown = false;


        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Flap");
            rigid.velocity = new Vector2(forwardSpeed, 0);
            rigid.AddForce(Vector2.up * 200f);
            rigid.rotation = defaultRotate;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        anim.SetTrigger("Dead");
        new WaitForSeconds(1f);
        //GameManager.Instance.GameOver();
    }
}
