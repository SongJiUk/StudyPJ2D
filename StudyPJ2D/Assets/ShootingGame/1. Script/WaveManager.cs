using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] GameObject[] waveScripts;

    int currentMove = 0;
    private void Awake()
    {

        for(int i =0; i<waveScripts.Length; i++)
        {
            waveScripts[i] = Instantiate(waveScripts[i], transform.position, Quaternion.identity);

            waveScripts[i].transform.SetParent(transform);
            waveScripts[i].SetActive(false);
        }
    }

    IEnumerator Start()
    { 
        if (waveScripts.Length == 0)
            yield break;

        while(true)
        {

            waveScripts[currentMove].SetActive(true);
            WaveScript wave = waveScripts[currentMove].GetComponent<WaveScript>();
            while (wave.ShipStillAlive())
            {
                yield return new WaitForEndOfFrame();
            }

            waveScripts[currentMove].SetActive(false);
            if (waveScripts.Length <= ++currentMove)
            {
                currentMove = 0;
            }

            if (currentMove == 0) break;
        }
    }
}
