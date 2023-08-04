using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveScript : MonoBehaviour
{
    GameObject[] waveShip;

    private void Awake()
    {
        //자식의 수만큼 배열 생성
        waveShip = new GameObject[transform.childCount];
        for(int i =0; i<waveShip.Length; i++)
        {
            waveShip[i] = transform.GetChild(i).gameObject;
        }
    }

    private void OnEnable()
    {
        for(int i =0; i<waveShip.Length; i++)
        {
            waveShip[i].SetActive(true);
        }
    }

    public bool ShipStillAlive()
    {
        for (int i = 0; i < waveShip.Length; i++)
        {
            if (waveShip[i].activeSelf) return true;
        }
        return false;
    }
}
