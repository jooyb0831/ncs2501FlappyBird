using System.Text;
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

    public void SetRank(int rank, int score, string date)
    {
        //랭크가 3이상이면 3을, 아니면 그 값을 인덱스로 함.
        int medalIdx = (rank > 2) ? 3 : rank;

        //메달 스프라이트에 있는 메달 선택(0금.1은.2동.3노메달)
        medalImg.sprite = mdealSprites[medalIdx];

        //랭크 값은 0부터이므로 +1
        rankTxt.text = (rank + 1).ToString();

        //랭크가 3 이상일 때만 표시
        rankTxt.gameObject.SetActive(rank>2);

        //string 연산을 많이하게 되므로 Stringbuilder를 사용함
        //"2025/04/08(줄바꿈)13:27:00"이런 형식으로 보이게 만든다.
        //date = 20250408132700;
        StringBuilder sb = new StringBuilder();
        sb.Append("20");
        int x = 0;
        while (x <= 10)
        {
            sb.Append(date.Substring(x, 2));
            if (x < 4)
            {
                sb.Append("/");
            }
            else if (x == 4)
            {
                sb.Append("\n");
            }
            else if (x > 4 && x < 10)
            {
                sb.Append(":");
            }
            else if (x == 10)
            {
                break;
            }
            x += 2;
        }
        /*
        sb.Append(date.Substring(0,2));
        sb.Append("/");
        sb.Append(date.Substring(2,2));
        sb.Append("/");
        sb.Append(date.Substring(4,2));
        sb.Append("\n");
        sb.Append(date.Substring(6,2));
        sb.Append(":");
        sb.Append(date.Substring(8,2));
        sb.Append(":");
        sb.Append(date.Substring(10,2));
        */

        dateTxt.text = sb.ToString();

        //점수표시
        scoreTxt.text = score.ToString();
    }
}
