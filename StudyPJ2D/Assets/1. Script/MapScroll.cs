using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScroll : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.CompareTag("BackGround"))
        {
            collision.transform.position += new Vector3(15f, 0, 0);
        }
       

    }
}
