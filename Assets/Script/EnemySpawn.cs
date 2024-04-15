using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // �� ������ �迭
    public Transform[] spawnPoints; // �� ���� ��ġ �迭
    public float spawnInterval = 2f; // ���� ����
    public float moveSpeed = 3f; // �̵� �ӵ�

    private Transform player; // �÷��̾� ��ġ
    private List<GameObject> spawnedEnemies = new List<GameObject>(); // ������ �� ����Ʈ

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // �÷��̾� �±׷� ã�Ƽ� �Ҵ�
        StartCoroutine(EnemySpawn());
    }

    IEnumerator EnemySpawn()
    {
        while (true)
        {
            // ������ ��ġ�� ������ �� ������ ����
            Vector2 randomPos = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
            GameObject randomEnemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

            // �� ���� �� ����Ʈ�� �߰�
            GameObject enemy = Instantiate(randomEnemyPrefab, randomPos, Quaternion.identity);
            spawnedEnemies.Add(enemy);

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void Update()
    {
        // �÷��̾ ���� ���� �� �̵� �� ���� ����
        if (player != null)
        {
            foreach (GameObject spawnedEnemy in spawnedEnemies)
            {
                if (spawnedEnemy != null)
                {
                    Vector3 moveDirection = (player.position - spawnedEnemy.transform.position).normalized;
                    spawnedEnemy.transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

                    if (moveDirection.x > 0) // �÷��̾ ���ʿ� ���� ��
                        spawnedEnemy.transform.localScale = new Vector3(1, 1, 1); // �⺻ ������
                    else // �÷��̾ �����ʿ� ���� ��
                        spawnedEnemy.transform.localScale = new Vector3(-1, 1, 1); // �¿� ����
                }
            }
        }
    }
}
