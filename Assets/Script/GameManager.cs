using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // 싱글톤
    public static GameManager Instance;
    public Text scoreText; // 점수
    public Text deathText; // 데스 카운트
    public Text itemCountText; // 아이템 갯수 텍스트
    public Button restartButton; // 재시작 버튼
    public Text deathscoreText; // 데스카운트 텍스트

    private int deathCnt = 0;
    int score = 0;
    int gold = 0;
    int itemCount = 0; // 아이템 갯수 변수 추가
    private bool gameEnded = false; // 게임이 끝났는지 여부를 저장하는 변수 추가

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void AddScore(int num)
    {
        score += num;
        scoreText.text = score.ToString();
    }

    // 아이템 갯수 추가 및 텍스트 갱신 메서드
    public void AddItem()
    {
        itemCount++;
        itemCountText.text = itemCount.ToString();
    }

    public void Die()
    {
        if (!gameEnded) // 게임이 끝나지 않은 경우에만 처리
        {
            Time.timeScale = 0f;
            deathCnt++;
            deathText.text = deathCnt.ToString();
            deathscoreText.text = score.ToString();
            deathText.gameObject.SetActive(true);
            deathscoreText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            gameEnded = true; // 게임 종료 상태로 설정

            restartButton.onClick.AddListener(RestartScene);
        }
    }

    public void RestartScene()
    {
        Time.timeScale = 1f; // 게임 다시 시작
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
