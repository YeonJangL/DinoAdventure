using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // 적 프리팹 배열
    public Transform[] spawnPoints; // 적 생성 위치 배열
    public float spawnInterval = 2f; // 생성 간격
    public float moveSpeed = 3f; // 이동 속도

    private Transform player; // 플레이어 위치
    private List<GameObject> spawnedEnemies = new List<GameObject>(); // 생성된 적 리스트

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // 플레이어 태그로 찾아서 할당
        StartCoroutine(EnemySpawn());
    }

    IEnumerator EnemySpawn()
    {
        while (true)
        {
            // 랜덤한 위치와 랜덤한 적 프리팹 선택
            Vector2 randomPos = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
            GameObject randomEnemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

            // 적 생성 및 리스트에 추가
            GameObject enemy = Instantiate(randomEnemyPrefab, randomPos, Quaternion.identity);
            spawnedEnemies.Add(enemy);

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void Update()
    {
        // 플레이어가 있을 때만 적 이동 및 반전 수행
        if (player != null)
        {
            foreach (GameObject spawnedEnemy in spawnedEnemies)
            {
                if (spawnedEnemy != null)
                {
                    Vector3 moveDirection = (player.position - spawnedEnemy.transform.position).normalized;
                    spawnedEnemy.transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

                    if (moveDirection.x > 0) // 플레이어가 왼쪽에 있을 때
                        spawnedEnemy.transform.localScale = new Vector3(1, 1, 1); // 기본 스케일
                    else // 플레이어가 오른쪽에 있을 때
                        spawnedEnemy.transform.localScale = new Vector3(-1, 1, 1); // 좌우 반전
                }
            }
        }
    }
}
