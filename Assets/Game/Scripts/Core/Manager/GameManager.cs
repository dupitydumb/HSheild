using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{  
    [SerializeField] private TMP_InputField playerNameInputField;
    public static GameManager Instance;
    [SerializeField] private ScoreSO scoreSO;
    [SerializeField] private string playerName;

    public string PlayerName
    {
        get { return playerName; }
        set { playerName = value; }
    }
    void Start()
    {
        Time.timeScale = 1;
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        scoreSO = ScoreSO.Instance;
        if (scoreSO == null)
        {
            Debug.LogError("ScoreSO instance is not assigned in the GameManager.");
        }
    }

    public void AddScoreToScoreData(int score)
    {
        ScoreSO.Instance.playerName = playerName;
        ScoreSO.Instance.score = scoreSO.score += score;
        
    }
    public void AddToScoreBoard(int score, string playerName)
    {
        PlayerScoreData newPlayerScore = new PlayerScoreData
        {
            playerName = playerName,
            score = score
        };
        scoreSO.playerScores.Add(newPlayerScore);
        scoreSO.SortList();
        scoreSO.playerScores.RemoveAll(x => x.playerName == playerName && x.score < score);
    }

    public string GetScoreData()
    {
        foreach (var playerScore in scoreSO.playerScores)
        {
            if (playerScore.playerName == playerName)
            {
                return playerScore.score.ToString();
            }
        }
        return "0";
    }

    public string GetAllScoreData()
    {
        string allScores = "";
        foreach (var playerScore in scoreSO.playerScores)
        {
            allScores += playerScore.playerName + ": " + playerScore.score + "\n";
        }
        return allScores;
    }

    public void ChangeScene(string sceneName)
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    public void StartGame()
    {
        if (playerNameInputField.text != "")
        {
            PlayerName = playerNameInputField.text;
            scoreSO.playerName = playerNameInputField.text;
            ChangeScene("L1");
        }
        else
        {
            playerNameInputField.placeholder.GetComponent<Text>().text = "Please enter your name!";
        }
    }

    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void LoadMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting...");
    }
}
