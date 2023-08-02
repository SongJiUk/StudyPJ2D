using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject bird_obj;

    float OffsetX = 0f;
    private void Start()
    {
        OffsetX = transform.position.x - bird_obj.transform.position.x;
    }
    void Update()
    {
        transform.position = new Vector3(
            bird_obj.transform.position.x + OffsetX,
            transform.position.y,
            transform.position.z);
        //Move();
    }
    private void Move()
    {
        Vector3 Dir = bird_obj.transform.position - transform.position;
        Dir.y = 0;
        Dir.z = 0;
        transform.position += Dir * Time.deltaTime;
    }
}
