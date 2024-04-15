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
        // 총알 이동
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }

    public void ShootBullet(Vector3 startPos)
    {
        // 총알 발사를 2초 지연시키기 위해 코루틴 사용
        StartCoroutine(ShootWithDelay(startPos));
    }

    private IEnumerator ShootWithDelay(Vector3 startPos)
    {
        yield return new WaitForSeconds(2f); // 2초 지연

        // 총알 오브젝트 생성
        GameObject bullet = Instantiate(gameObject, startPos, Quaternion.identity);
        // 총알 방향을 오른쪽으로 설정
        bullet.GetComponent<PBullet>().moveSpeed = Mathf.Abs(moveSpeed);
    }

    // 화면 밖으로 나가면 제거
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().Damage(Attack);

            // 폭발 이펙트
            GameObject go = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(go, 0.3f);

            Destroy(gameObject);
        }

        if (collision.tag == "Enemy2")
        {
            collision.gameObject.GetComponent<Enemy>().Damage2(Attack);

            // 폭발 이펙트
            GameObject go = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(go, 0.3f);

            Destroy(gameObject);
        }
    }
}
