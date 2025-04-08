using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    private GameManager gameMgr;
    private ScoreManager scoreMgr;
    [SerializeField] Image medalImg;
    [SerializeField] Sprite[] medalSprites;
    [SerializeField] TMP_Text scoreTxt;
    [SerializeField] TMP_Text bestScoreTxt;
    private void Start()
    {
        gameMgr = GameManager.Instance;
        scoreMgr = ScoreManager.Instance;
    }

    public void UpdateResult()
    {
        if (scoreMgr == null)
        {
            scoreMgr = ScoreManager.Instance;
        }

        //3등 안이면 메달 표시
        if (scoreMgr.Rank <= 3)
        {
            medalImg.gameObject.SetActive(true);
            medalImg.sprite = medalSprites[scoreMgr.Rank];
        }
        else
        {
            medalImg.gameObject.SetActive(false);
        }
        scoreTxt.text = scoreMgr.Score.ToString();

        //todo:베스트스코어
        bestScoreTxt.text = PlayerPrefs.GetInt("RANKSCORE0", 0).ToString();
    }
}
