using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //프로그램 시작할때 올라감

    public static GameManager Instance = null;

    [SerializeField] Text score_txt;
    [SerializeField] Image gameOver_Img;
    int score = 0;

    void Start()
    {
        if (null == Instance) Instance = this;
        else Destroy(this.gameObject);
    }

    public void AddScore()
    {
        score++;
        score_txt.text = $"점수 : {score}";
    }

    public void GameOver()
    {
        gameOver_Img.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

}
