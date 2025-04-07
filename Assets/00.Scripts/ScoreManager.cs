using System.Data.Common;
using TMPro;
using UnityEngine;


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
    private int score = 0;
    public int Score => score;
    private int rank = 0;
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
        data.Rank1 = PlayerPrefs.GetInt("RANK1");
        data.Rank2 = PlayerPrefs.GetInt("RANK2");
        data.Rank3 = PlayerPrefs.GetInt("RANK3");
    }

    public void UpdateScore(int value)
    {
        score += value;
        scoreText.text = score.ToString();
    }

    public void CheckBestScore()
    {
        //todo 실제 랭크 계산

        gameoverUI.UpdateResult();
    }
}
