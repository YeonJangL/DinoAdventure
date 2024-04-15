using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 2f;
    public int HP = 10;
    public GameObject Item;
    public GameObject deathEffect; // 죽을 때 표시할 이펙트

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public void Damage(int attack)
    {
        HP -= attack;
        ChangeEnemyColor();

        if (HP <= 0)
        {
            // 점수
            GameManager.Instance.AddScore(10);

            ItemDrop();
            Destroy(gameObject);
        }
    }

    public void Damage2(int attack)
    {
        HP -= attack;
        ChangeEnemyColor();

        if (HP <= 0)
        {
            // 점수
            GameManager.Instance.AddScore(20);

            ItemDrop();
            Destroy(gameObject);
        }
    }

    IEnumerator DestroyEnemyWithEffect()
    {
        // 죽음 이펙트 보이기
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);

        // 죽음 이펙트를 잠시 보여준 후 삭제
        yield return new WaitForSeconds(0.2f);

        // 죽음 이펙트 삭제
        Destroy(effect);

        // 적 제거
        Destroy(gameObject);
    }

    public void ChangeEnemyColor()
    {
        SpriteRenderer[] renderers = transform.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer renderer in renderers)
        {
            renderer.color = Color.white;
        }
    }

    public void ItemDrop()
    {
        // 아이템 생성
        Instantiate(Item, transform.position, Quaternion.identity);
    }
}
