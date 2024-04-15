using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PBullet : MonoBehaviour
{
    public float moveSpeed = 1.5f;
    public GameObject explosion;
    public int Attack = 10;

    // Update is called once per frame
    void Update()
    {
        // �Ѿ� �̵�
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }

    public void ShootBullet(Vector3 startPos)
    {
        // �Ѿ� �߻縦 2�� ������Ű�� ���� �ڷ�ƾ ���
        StartCoroutine(ShootWithDelay(startPos));
    }

    private IEnumerator ShootWithDelay(Vector3 startPos)
    {
        yield return new WaitForSeconds(2f); // 2�� ����

        // �Ѿ� ������Ʈ ����
        GameObject bullet = Instantiate(gameObject, startPos, Quaternion.identity);
        // �Ѿ� ������ ���������� ����
        bullet.GetComponent<PBullet>().moveSpeed = Mathf.Abs(moveSpeed);
    }

    // ȭ�� ������ ������ ����
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().Damage(Attack);

            // ���� ����Ʈ
            GameObject go = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(go, 0.3f);

            Destroy(gameObject);
        }

        if (collision.tag == "Enemy2")
        {
            collision.gameObject.GetComponent<Enemy>().Damage2(Attack);

            // ���� ����Ʈ
            GameObject go = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(go, 0.3f);

            Destroy(gameObject);
        }
    }
}
