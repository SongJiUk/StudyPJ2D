using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 3f;

 
    void Update()
    {
        Vector3 input = Vector3.zero;

        if(Input.GetKey(KeyCode.A))
        {
            input += new Vector3(-1f, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            input += new Vector3(1f, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            input += new Vector3(0, -1f, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            input += new Vector3(0, 1f, 0);
        }


        input.Normalize();

        transform.position += input * Time.deltaTime * speed;
    }
}
