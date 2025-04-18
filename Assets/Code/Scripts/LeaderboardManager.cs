using System.IO;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LeaderboardEntry
{
    public string playerName;
    public int score;

    public LeaderboardEntry(string name, int score)
    {
        this.playerName = name;
        this.score = score;
    }
}

[System.Serializable]
public class LeaderboardData
{
    public List<LeaderboardEntry> entries = new List<LeaderboardEntry>();
}

public class LeaderboardManager : MonoBehaviour
{
    public static LeaderboardManager Instance;

    private List<LeaderboardEntry> leaderboard = new List<LeaderboardEntry>();
    private const string SaveKey = "LeaderboardData";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keeps this across scene reloads
            LoadLeaderboard();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddEntry(string playerName, int score)
    {
        leaderboard.Add(new LeaderboardEntry(playerName, score));
        leaderboard.Sort((a, b) => b.score.CompareTo(a.score)); // Highest score first
        SaveLeaderboard();
    }

    public List<LeaderboardEntry> GetTopScores(int count = 5)
    {
        return leaderboard.GetRange(0, Mathf.Min(count, leaderboard.Count));
    }

    private void SaveLeaderboard()
    {
        LeaderboardData data = new LeaderboardData();
        data.entries = leaderboard;

        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(SaveKey, json);
        PlayerPrefs.Save();
    }

    private void LoadLeaderboard()
    {
        if (PlayerPrefs.HasKey(SaveKey))
        {
            string json = PlayerPrefs.GetString(SaveKey);
            LeaderboardData data = JsonUtility.FromJson<LeaderboardData>(json);
            leaderboard = data.entries;
        }
    }
}
