using UnityEngine;

public class MovePipe : MonoBehaviour
{
    [SerializeField] BoxCollider2D upPipe;
    [SerializeField] BoxCollider2D downPipe;
    [SerializeField] float speed = 0.65f;
    private void Update()
    {
        if (GameManager.Instance.GameState == GameManager.State.PLAY)
        {
            //파이프의 위치를 speed 만큼 좌로 이동
            transform.position += Vector3.left * Time.deltaTime * speed;
        }
        else if (GameManager.Instance.GameState == GameManager.State.GAMEOVER)
        {
            //게임 오버에서는 파이프 충돌 안되게끔
            upPipe.enabled = false;
            downPipe.enabled = false;
        }
    }
}
