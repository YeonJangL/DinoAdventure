using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 7.0f;
    public GameObject bulletPrefab;
    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;
    public LayerMask whatIsGround;

    private bool isGrounded = false;
    private bool isDead = false;

    private Rigidbody2D playerRbody;
    private Animator animator;
    private AudioSource playerAudio;

    void Start()
    {
        playerRbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        // 지면 감지
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            ShootBullet();
        }
    }

    void Jump()
    {
        if (isGrounded)
        {
            playerRbody.velocity = Vector2.up * jumpForce;
        }
    }

    void ShootBullet()
    {
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    }

    void Die()
    {
        GameManager.Instance.Die(); // GameManager의 Die 메서드 호출
        isDead = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Enemy2")) && !isDead)
        {
            Die();
        }
    }

    // Animation Event로 호출하여 점프 애니메이션 종료 시 호출되는 메서드
    public void FinishJump()
    {
        animator.SetBool("Jump", false);
    }
}
