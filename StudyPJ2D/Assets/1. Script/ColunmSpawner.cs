using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColunmSpawner : MonoBehaviour
{
    [SerializeField] GameObject ColumPrefab;
    void Start()
    {
        Instantiate(ColumPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        StartCoroutine(twoSecond());
    }

    float timer = 0f;

    IEnumerator twoSecond()
    {
        while(true)
        {
            float rand = Random.Range(-2f, 2f);
            Instantiate(ColumPrefab, new Vector3(transform.position.x, rand, 0), Quaternion.identity);
            yield return new WaitForSeconds(3f);
        }
        
    }

    private void Update()
    {
        //timer += Time.deltaTime;

        //if (timer >= 3f)
        //{
        //    float rand = Random.Range(-2f, 2f);
        //    Instantiate(ColumPrefab, new Vector3(transform.position.x, rand, 0), Quaternion.identity);
        //    timer = 0f;
        //}
    }
}
