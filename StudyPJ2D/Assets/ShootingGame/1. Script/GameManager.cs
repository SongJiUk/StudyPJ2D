using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [Header("처음 시작 부분 필요")]
    [SerializeField] GameObject player;
    [SerializeField] GameObject Wave;
    [SerializeField] GameObject Title_txt;

    [Header("점수")]
    [SerializeField] Text score_txt;
    [SerializeField] Text high_score_txt;
    int score = 0;
    int HighScore = 0;
    private void Awake()
    {
        if (null == instance) instance = this;
        else Destroy(this.gameObject);
        HighScore = Road();
    }

    public void Save()
    {
        score = 0;
        PlayerPrefs.SetInt("HighScore", HighScore);

    }

    int Road()
    {
        int h_score = PlayerPrefs.GetInt("HighScore", 0);
        high_score_txt.text = $"HIGHSCORE : {h_score}";
        return h_score;
    }

    void GameStart()
    {
        player.SetActive(true);
        Wave.SetActive(true);
        Title_txt.SetActive(false);
    }

    private void Update()
    {
        if(Title_txt.activeSelf)
        {
            if (Input.anyKeyDown)
            {
                GameStart();
            }
        }
        
    }
    public void AddScore(int point)
    {
        score += point;
        if (HighScore <= score)
        {
            HighScore = score;
            high_score_txt.text = $"HIGHSCORE : {HighScore}";
        }
        score_txt.text = $"SCORE : {score}";
    }

    public void Restart()
    {
        player.SetActive(false);
        Wave.SetActive(false);
        Title_txt.SetActive(true);
        Save();
        score_txt.text = $"SCORE : {score}";
    }
}
