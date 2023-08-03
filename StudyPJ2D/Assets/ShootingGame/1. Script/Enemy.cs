using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Animator anim;
    int HP;

    void Start()
    {
        HP = 5;
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bullet"))
        {
            Hit();
        }
    }
    public void Hit()
    {
        HP--;
        if (HP == 0)
        {
            Dead();
        }
        else anim.SetTrigger("IsHit");
    }

  

    public void Dead()
    {
        Destroy(this.gameObject);
    }
}
