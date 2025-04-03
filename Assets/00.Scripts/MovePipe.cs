using UnityEngine;

public class MovePipe : MonoBehaviour
{
    [SerializeField] float speed = 0.65f;
    private void Update()
    {
        //파이프의 위치를 speed 만큼 좌로 이동
        transform.position += Vector3.left * Time.deltaTime * speed;
    }
}
