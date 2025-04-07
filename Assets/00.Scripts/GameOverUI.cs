using TMPro;
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
        //3등 안이면 메달 표시
        if(scoreMgr.Rank <= 3)
        {
            switch(scoreMgr.Rank)
            {
                case 3 :
                medalImg.sprite = medalSprites[3];
                break;
                case 2 :
                medalImg.sprite = medalSprites[2];
                break;
                case 1 :
                medalImg.sprite = medalSprites[1];
                break;
            }
        }
        else
        {
            //medalImg.sprite = medalSprites[0];
            medalImg.gameObject.SetActive(false);
        }
        scoreTxt.text = scoreMgr.Score.ToString();
        //todo:베스트스코어
    }
}
