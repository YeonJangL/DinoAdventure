using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // 아이템 가속 속도
    public float itemVelocity = 20f;
    Rigidbody2D rig = null;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();

        // 플레이어 오브젝트를 찾아 할당
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            Transform player = playerObject.transform;

            // 플레이어 쪽으로 향하는 방향 계산
            Vector2 direction = (player.position - transform.position).normalized;

            // 플레이어 쪽으로 가속도 적용
            rig.velocity = direction * itemVelocity;
        }
    }

    // 충돌 감지
    void OnTriggerEnter2D(Collider2D collision)
    {
        // 충돌한 대상이 플레이어인 경우
        if (collision.CompareTag("Player"))
        {
            // 아이템 갯수 증가
            GameManager.Instance.AddItem();

            // 아이템 오브젝트 삭제
            Destroy(gameObject);
        }
    }
}
