using System;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public int score;
    public TMP_Text scoreText;
    public TMP_Text highScoreText;
    public Action onScoreChanges;
    public GameObject scorePanel;
    public TMP_Text endScoreText;
    public GameObject scorePrefab;
    public GameObject scoreBoard;
    bool isLastLevel = false;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        score = 0;
        UpdateScore();
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateScore();
    }

    public void UpdateScore()
    {
        scoreText.text = score.ToString();
        onScoreChanges?.Invoke();
    }

    public void ShowScorePanel()
    {
        Time.timeScale = 0;
        scorePanel.SetActive(true);
        endScoreText.text = score.ToString();
        GameManager.Instance.AddScoreToScoreData(score);
    }

    public void ShowTotalScorePanel()
    {
        GameManager.Instance.AddScoreToScoreData(score);
        GameManager.Instance.AddToScoreBoard(score, GameManager.Instance.PlayerName);
        Time.timeScale = 0;
        scorePanel.SetActive(true);
        endScoreText.text = ScoreSO.Instance.score.ToString();
        int position = 1;
        foreach (var playerScore in ScoreSO.Instance.playerScores)
        {
            GameObject scoreObject = Instantiate(scorePrefab, scoreBoard.transform);
            TMP_Text positionText = scoreObject.transform.GetChild(0).GetComponent<TMP_Text>();
            TMP_Text playerNameText = scoreObject.transform.GetChild(1).GetComponent<TMP_Text>();
            TMP_Text playerScoreText = scoreObject.transform.GetChild(2).GetComponent<TMP_Text>();
            positionText.text = position.ToString();
            playerNameText.text = playerScore.playerName;
            playerScoreText.text = playerScore.score.ToString();
            position++;
        }
    }
    public void HideScorePanel()
    {
        Time.timeScale = 1;
        scorePanel.SetActive(false);
    }
}
