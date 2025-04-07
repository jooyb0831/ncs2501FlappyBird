using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RankUI : MonoBehaviour
{
    [SerializeField] Sprite[] mdealSprites;
    [SerializeField] Image medalImg;
    [SerializeField] TMP_Text rankTxt;
    [SerializeField] TMP_Text dateTxt;
    [SerializeField] TMP_Text scoreTxt;

    public int inputRank;

    void Start()
    {
        SetRank(inputRank, 100, null);
    }   
    public void SetRank(int rank, int score, string date)
    {
    
        //랭크 값은 0부터이므로 +1
        //랭크가 3 이상일 때만 표시
        if(rank>2)
        {
            rankTxt.gameObject.SetActive(true);
        }

        //랭크가 3이상이면 3을, 아니면 그 값을 인덱스로 함.
        int medalIdx = (rank > 2) ? 3 : rank;

        //메달 스프라이트에 있는 메달 선택(0금.1은.2동.3노메달)
        medalImg.sprite = mdealSprites[medalIdx];

        rankTxt.text = (rank + 1).ToString();
        scoreTxt.text = score.ToString();
        
    }
}
