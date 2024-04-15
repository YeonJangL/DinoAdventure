using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // �̱���
    public static GameManager Instance;
    public Text scoreText; // ����
    public Text deathText; // ���� ī��Ʈ
    public Text itemCountText; // ������ ���� �ؽ�Ʈ
    public Button restartButton; // ����� ��ư
    public Text deathscoreText; // ����ī��Ʈ �ؽ�Ʈ

    private int deathCnt = 0;
    int score = 0;
    int gold = 0;
    int itemCount = 0; // ������ ���� ���� �߰�
    private bool gameEnded = false; // ������ �������� ���θ� �����ϴ� ���� �߰�

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

    // ������ ���� �߰� �� �ؽ�Ʈ ���� �޼���
    public void AddItem()
    {
        itemCount++;
        itemCountText.text = itemCount.ToString();
    }

    public void Die()
    {
        if (!gameEnded) // ������ ������ ���� ��쿡�� ó��
        {
            Time.timeScale = 0f;
            deathCnt++;
            deathText.text = deathCnt.ToString();
            deathscoreText.text = score.ToString();
            deathText.gameObject.SetActive(true);
            deathscoreText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            gameEnded = true; // ���� ���� ���·� ����

            restartButton.onClick.AddListener(RestartScene);
        }
    }

    public void RestartScene()
    {
        Time.timeScale = 1f; // ���� �ٽ� ����
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
