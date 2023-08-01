using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScroll : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.CompareTag("obstacle"))
        {
            //float rand = Random.Range(20f, 30f);
            //collision.transform.position += new Vector3(rand, 0, 0);
        }
        else
        {
            collision.transform.position += new Vector3(15f, 0, 0);

        }

    }
}
