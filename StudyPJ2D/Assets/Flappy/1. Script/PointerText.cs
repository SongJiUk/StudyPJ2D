using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerText : MonoBehaviour
{
    //ref - ����(���� �� �ȳ־��൵ ��) out - ���� �� �־������.
    void swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }

    void swap2(out int a, out int b)
    {
        a = 10;
        b = 20;
    }
    void Start()
    {
        int a = 1;
        int b = 2;

        swap(ref a, ref b);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
