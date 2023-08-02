using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColunmSpawner : MonoBehaviour
{
    [SerializeField] GameObject ColumPrefab;

    GameObject[] ColumsArray;
    void Start()
    {

        ColumsArray = new GameObject[5];
        for (int i = 0; i < ColumsArray.Length; i++)
        {

            ColumsArray[i] = Instantiate(ColumPrefab);
            ColumsArray[i].SetActive(false);
        }
        //Instantiate(ColumPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        StartCoroutine(twoSecond());
    }



    int ColulmnIndex = 0;
    IEnumerator twoSecond()
    {
        while (true)
        {
            // 웹사이트 기다림 
            // yield return new WWW;
            yield return new WaitForSeconds(3f);
            float rand = Random.Range(-2f, 2f);
            ColumsArray[ColulmnIndex].SetActive(true);
            ColumsArray[ColulmnIndex++].transform.position = new Vector3(transform.position.x, rand, 0);
            if (ColulmnIndex >= ColumsArray.Length) ColulmnIndex = 0;
        }

    }
}