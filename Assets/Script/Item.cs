using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // ������ ���� �ӵ�
    public float itemVelocity = 20f;
    Rigidbody2D rig = null;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();

        // �÷��̾� ������Ʈ�� ã�� �Ҵ�
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            Transform player = playerObject.transform;

            // �÷��̾� ������ ���ϴ� ���� ���
            Vector2 direction = (player.position - transform.position).normalized;

            // �÷��̾� ������ ���ӵ� ����
            rig.velocity = direction * itemVelocity;
        }
    }

    // �浹 ����
    void OnTriggerEnter2D(Collider2D collision)
    {
        // �浹�� ����� �÷��̾��� ���
        if (collision.CompareTag("Player"))
        {
            // ������ ���� ����
            GameManager.Instance.AddItem();

            // ������ ������Ʈ ����
            Destroy(gameObject);
        }
    }
}
