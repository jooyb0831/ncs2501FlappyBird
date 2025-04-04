using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] float maxTime = 1.5f; // 몇 초마다 생성할지
    [SerializeField] float heightRange = 0.5f; // 생성 위치 y의 랜덤 범위
    [SerializeField] GameObject pipePrefab; // 생성할 파이프 프리팹
    [SerializeField] GameObject redPipePrefab; // 빨간 파이프 프리팹

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
        GameObject pipePf = (Random.Range(0, 100) > 20) ? pipePrefab : redPipePrefab;
        GameObject obj = Instantiate(pipePf, spawnPos, Quaternion.identity);
        Destroy(obj, 7f);
    }
}
