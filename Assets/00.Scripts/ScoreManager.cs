using System.Data.Common;
using TMPro;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class ScoreData
{
    public int Rank1 { get; set; }
    public int Rank2 { get; set; }
    public int Rank3 { get; set; }

}

//Paint.NET : 이미지 편집 쉽게 할 수 있음
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] GameOverUI gameoverUI;
    [SerializeField] BestScoreUI bsUI;
    private int score = 0;
    public int Score => score;
    private int rank;
    public int Rank => rank;
    ScoreData data = new ScoreData();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        scoreText.text = score.ToString();
    }

    void Start()
    {

    }

    public void UpdateScore(int value)
    {
        score += value;
        scoreText.text = score.ToString();
    }

    public void CheckBestScore()
    {
        rank = bsUI.CaculateRank(score);
        gameoverUI.UpdateResult();
    }

#if UNITY_EDITOR
    //베스트 스코어 리셋
    [MenuItem("FlappyBird/ResetBestScore")]
    public static void ResetBestScore()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Best Score reset");
    }
#endif
}
