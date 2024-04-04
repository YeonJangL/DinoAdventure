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
        // 사용할 컴포넌트 가져와서 변수에 할당
        playerRbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // 점프
        if (isDead) // 이미 죽었으면 리턴
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
        {
            playerRbody.velocity = Vector2.zero; // 직전 속도에 영향 받지 않기 위해서 점프할때 속도를 0으로 함
            playerRbody.AddForce(new Vector2 (0, 0));
            playerAudio.Play();
        }

        animator.SetBool("Gorounded", isGrounded);
    }

    private void Die()
    {
        // 죽을때
        animator.SetTrigger("Die");

        playerAudio.clip = dieClip;
        playerAudio.Play();

        playerRbody.velocity = Vector2.zero;

        isDead = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 적이랑 충돌 감지
        if (collision.gameObject.CompareTag("Enemy") && !isDead)
        {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // 바닥 충돌 감지
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // 점프 감지
        isGrounded = false;
    }
}
