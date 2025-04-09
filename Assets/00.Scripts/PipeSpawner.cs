using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] float maxTime = 1.5f; // 몇 초마다 생성할지
    [SerializeField] float heightRange = 0.5f; // 생성 위치 y의 랜덤 범위
    [SerializeField] GameObject[] pipePrefab; // 생성할 파이프 프리팹
    [SerializeField] GameObject[] redPipePrefab; // 빨간 파이프 프리팹

    const int MAX_PIPE = 3; //오브젝트 풀링을 위해 미리 만들어 놓을 최대 파이프 수
    int pipeIdx = 0; //오브젝트 풀링을 위한 인덱스 저장용 변수
    private float timer;

    private void Update()
    {
        //게임 상태가 PLAY 일때만 PIPE를 생성
        if (GameManager.Instance.GameState != GameManager.State.PLAY)
        {
            return;
        }
        timer += Time.deltaTime;
        if (timer >= maxTime)
        {
            GeneratePipe();
            timer = 0;
        }
    }

    void GeneratePipe()
    {
        //랜덤으로 y값을 정해서 생성될 파이프 위치 정하기
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-heightRange, heightRange));
        //float y = Random.Range(-heightRange, heightRange);
        //Vector3 pos = new Vector3(1f, y);
        //랜덤으로 녹색, 빨간색 파이프 선택
        //GameObject pipePf = (Random.Range(0, 100) > 20) ? pipePrefab : redPipePrefab;
        //GameObject obj = Instantiate(pipePf, spawnPos, Quaternion.identity);
        //Destroy(obj, 7f);

        //오브젝트 풀링
        if (Random.Range(0, 100) > 10)
        {
            //일반 파이프 불러오기
            pipePrefab[pipeIdx].transform.SetPositionAndRotation(spawnPos, Quaternion.identity);
            pipePrefab[pipeIdx].GetComponent<MovePipe>().isMoving = true;
        }
        else
        {
            //빨간 파이프 불러오기
            redPipePrefab[pipeIdx].transform.SetPositionAndRotation(spawnPos, Quaternion.identity);
            redPipePrefab[pipeIdx].GetComponent<MovePipe>().isMoving = true;
        }

        //최대 파이프 갯수에 도달하면
        if (++pipeIdx >= MAX_PIPE)
        {
            pipeIdx = 0;
        }
    }
}
