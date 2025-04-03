using TMPro;
using UnityEngine;


//Paint.NET : 이미지 편집 쉽게 할 수 있음
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [SerializeField] TMP_Text scoreText;
    private int score = 0;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        scoreText.text = score.ToString();
    }

    public void UpdateScore(int value)
    {
        score += value;
        scoreText.text = score.ToString();
    }
}
