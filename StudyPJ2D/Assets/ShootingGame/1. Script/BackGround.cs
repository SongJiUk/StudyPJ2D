using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{

    [SerializeField] List<MeshRenderer> mr = new List<MeshRenderer>();

    float Backspeed = 1f;
    float Middlespeed = 0.5f;
    float Frontspeed = 0.1f;
    Vector2 offset = Vector2.zero;
    private void Update()
    {
        
        for (int i=0; i<mr.Count; i++)
        {
            if(i == 0)
            {
                offset = new Vector2(0, Time.time * Backspeed);
            }
            else offset = new Vector2(0, Time.time * Middlespeed);

            mr[i].material.SetTextureOffset("_MainTex", offset);
        }

    }

}
