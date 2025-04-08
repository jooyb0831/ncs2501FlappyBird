using UnityEngine;
//using을 사용해서 자주 사용하는 namespace나 enum을 줄여 쓸 수 있음
using GMState = GameManager.State;

public class BirdControl : MonoBehaviour
{
    Rigidbody2D rb;

    private GameManager gameMgr;

    [SerializeField] float velocity = 1.5f;
    [SerializeField] float rotateSpeed = 10f;
    [SerializeField] AudioClip acWing;
    [SerializeField] AudioClip acDie;
    [SerializeField] Animator flapAnim;
    [SerializeField] Animator birdAnim;
    [SerializeField] AudioClip acReady;
    private void Start()
    {   
        //게임매니저 받아오기
        gameMgr = GameManager.Instance;

        //rigidbody2D 연결
        rb = GetComponent<Rigidbody2D>();
        //bird가 안 떨어지게 중력 값 조정
        rb.gravityScale = 0;
    }

    private void Update()
    {
        //마우스 클릭(화면 터치)하면 위로 움직이게
        if (Input.GetMouseButtonDown(0))
        {
            //게임 상태가 ready이면
            if (gameMgr.GameState == GMState.READY)
            {
                gameMgr.GamePlay();
            }
            
            //게임 상태가 Play이면
            else if (gameMgr.GameState == GMState.PLAY)
            {
                //Velocity 값을 변환해서 위쪽으로 가게함
                //아래 회전값을 주기 위해 velocity사용
                rb.velocity = Vector2.up * velocity;
                //새가 나는 소리 재생
                gameMgr.PlayAudio(acWing);
                //클릭했을 때 떨어지도록 중력 값 조정
                if(rb.gravityScale == 0)
                {
                    rb.gravityScale = 1;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        //Update이후에 호출됨. Update에서 변경된 Velocity의 y값만큼 회전.
        transform.rotation = Quaternion.Euler(0, 0, rb.velocity.y * rotateSpeed);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //게임 플레이 중일 때만
        if(gameMgr.GameState != GMState.PLAY) return;
        gameMgr.GameOver();
        flapAnim.enabled = false;
        
        if(transform.position.y > -0.3f)
        {
            gameMgr.PlayAudio(acDie);
        }
        Debug.Log("GameOver");
    }

    public void BirdReady()
    {
        //새 뒤로 움직임
        birdAnim.SetTrigger("Ready");
        gameMgr.PlayAudio(acReady);
    }

    public void BirdPlay()
    {
        birdAnim.enabled = false;
    }

    public void BirdDead()
    {

    }
}
