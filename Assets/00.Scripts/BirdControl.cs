using UnityEngine;

public class BirdControl : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] float velocity = 1.5f;
    [SerializeField] float rotateSpeed = 10f;

    private void Start()
    {
        //rigidbody2D 연결
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //마우스 클릭(화면 터치)하면 위로 움직이게
        if(Input.GetMouseButtonDown(0))
        {
            //Velocity 값을 변환해서 위쪽으로 가게함
            //아래 회전값을 주기 위해 velocity사용
            rb.velocity = Vector2.up * velocity;
        }
    }

    private void FixedUpdate()
    {
        //Update이후에 호출됨. Update에서 변경된 Velocity의 y값만큼 회전.
        transform.rotation = Quaternion.Euler(0, 0, rb.velocity.y * rotateSpeed);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //todo:게임오버
        GameManager.Instance.GameOver();
        Debug.Log("GameOver");
    }
}
