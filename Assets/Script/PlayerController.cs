using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip dieClip;
    public float jump = 7.0f;
    public float moveSpeed = 3.0f;

    private int deathCnt = 0;
    private bool isGrounded = false;
    private bool isDead = false;

    private Rigidbody2D playerRbody;
    private Animator animator;
    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        // ����� ������Ʈ �����ͼ� ������ �Ҵ�
        playerRbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // ����
        if (isDead) // �̹� �׾����� ����
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
        {
            playerRbody.velocity = Vector2.zero; // ���� �ӵ��� ���� ���� �ʱ� ���ؼ� �����Ҷ� �ӵ��� 0���� ��
            playerRbody.AddForce(new Vector2 (0, 0));
            playerAudio.Play();
        }

        animator.SetBool("Gorounded", isGrounded);
    }

    private void Die()
    {
        // ������
        animator.SetTrigger("Die");

        playerAudio.clip = dieClip;
        playerAudio.Play();

        playerRbody.velocity = Vector2.zero;

        isDead = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ���̶� �浹 ����
        if (collision.gameObject.CompareTag("Enemy") && !isDead)
        {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // �ٴ� �浹 ����
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // ���� ����
        isGrounded = false;
    }
}
