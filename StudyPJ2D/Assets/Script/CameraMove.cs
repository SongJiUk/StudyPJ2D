using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject bird_obj;
   
    void Start()
    {
        
    }


    void Update()
    {
        Move();
    }

    public void Move()
    {
        Vector3 Dir = bird_obj.transform.position - transform.position;
        Dir.y = 0;
        Dir.z = 0;

        transform.position += Dir * Time.deltaTime;
    }
}
