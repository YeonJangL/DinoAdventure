using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 2f;
    public int HP = 10;
    public GameObject Item;
    public GameObject deathEffect; // ���� �� ǥ���� ����Ʈ

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
            // ����
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
            // ����
            GameManager.Instance.AddScore(20);

            ItemDrop();
            Destroy(gameObject);
        }
    }

    IEnumerator DestroyEnemyWithEffect()
    {
        // ���� ����Ʈ ���̱�
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);

        // ���� ����Ʈ�� ��� ������ �� ����
        yield return new WaitForSeconds(0.2f);

        // ���� ����Ʈ ����
        Destroy(effect);

        // �� ����
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
        // ������ ����
        Instantiate(Item, transform.position, Quaternion.identity);
    }
}
