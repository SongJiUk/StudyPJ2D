using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//값 저장! 
struct TestPoint
{
    public int a;
    public int b;
}

//클래스는 안써줘도 ref.
public class SpaceShip : MonoBehaviour
{

    void TestFct(ref TestPoint point)
    {

    }

    void Start()
    {
        TestPoint point;
        point.a = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
