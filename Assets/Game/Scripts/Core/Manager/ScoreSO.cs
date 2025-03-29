using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScoreSO", menuName = "ScriptableObjects/ScoreSO", order = 1)]
public class ScoreSO : ScriptableObject
{
    public static ScoreSO Instance;
    public string playerName;
    public int score;
    private void OnEnable()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("Multiple instances of ScoreSO detected. Destroying the new instance.");
            DestroyImmediate(this);
        }
    }

    public void SortList()
    {
        playerScores.Sort((x, y) => y.score.CompareTo(x.score));
    }

    public List<PlayerScoreData> playerScores = new List<PlayerScoreData>();

}

[System.Serializable]
public class PlayerScoreData
{
    public string playerName;
    public int score;
}
