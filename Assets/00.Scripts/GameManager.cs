using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //게임 상태를 저장할 enum
    public enum State
    {
        TITLE,      //0 : 0
        READY,      //1 : 1
        PLAY,       //2 : 0
        GAMEOVER,   //3 : 1
        BESTSCORE   //4 : 0
    }

    public static GameManager Instance;


    //new AudioSource audio;//audio가 이미 있어서 new로 선언해야 함
    private AudioSource audioSoruce; 
    

    [SerializeField] BirdControl bird;
    [SerializeField] SpriteRenderer backGround;
    [SerializeField] GameObject restartBtn;
    [SerializeField] GameObject[] stateUI; // 각 상태의 UI
    [SerializeField] Sprite[] bgSprite;
    [SerializeField] Animator floorAnim;
    [SerializeField] Animator birdAnim;
    [SerializeField] AudioClip acReady;
    [SerializeField] AudioClip acHit;


    private State gameState; //게임 상태를 저장할 변수
    public State GameState => gameState;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {   
        //오디오 소스 연결
        audioSoruce = GetComponent<AudioSource>();

        //정상적인 게임 시간 흐르게
        Time.timeScale = 1.0f;

        //게임의 시작은 TITLE에서
        GameTitle();
    }

    /// <summary>
    /// State에 따라서 BG와 UI 변경하는 함수
    /// </summary>
    /// <param name="value"></param>
    void ChangeState(State value)
    {
        gameState = value;
        //stateUI에 있는 모든 UI를 끈다.
        foreach(var item in stateUI)
        {
            item.SetActive(false);
        }
        
        //State값을 공동으로 사용하므로 미리 int값으로 변환
        int temp = (int)gameState;

        //해당하는 backGround sprite 연결
        backGround.sprite = bgSprite[temp % 2];

        //해당하는 stateUI켜기
        stateUI[temp].SetActive(true);
    }

    public void PlayAudio(AudioClip clip)
    {
        //파라미터로 넘어온 오디오 클립을 한 번 플레이시킨다.
        audioSoruce.PlayOneShot(clip);
    }

    public void GameTitle()
    {
        ChangeState(State.TITLE);
    }

    public void GameReady()
    {
        ChangeState(State.READY);
        bird.BirdReady();
    }

    public void GamePlay()
    {
        ChangeState(State.PLAY);
        bird.BirdPlay();
    }
    public void GameOver()
    {
        //부딪히는 소리
        PlayAudio(acHit);
        ChangeState(State.GAMEOVER);

        //바닥 애니메이션 멈추기
        floorAnim.enabled = false;

        //베스트 스코어 체크
        ScoreManager.Instance.CheckBestScore();
        
        //restart버튼은 일단 꺼둠
        restartBtn.SetActive(false);
        
        //코루틴을 사용하여 잠시 시간을 지연시킨다.
        StartCoroutine(nameof(StopTimer));
    }

    IEnumerator StopTimer()
    {   
        //2초 기다렸다 다음 로직
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0;

        //Restart 버튼 나오게
        restartBtn.SetActive(true);

    }
    
    public void BestScore()
    {
        ChangeState(State.BESTSCORE);
    }

    public void RestartGame()
    {
        Time.timeScale = 2;
        
        //현재 씬을 다시 불러오기
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
