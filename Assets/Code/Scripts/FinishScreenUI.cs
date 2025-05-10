using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FinishScreenUI : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText;
    public TMP_InputField nameInputField;
    public TextMeshProUGUI leaderboardText;
    public Button submitButton;

    public GameObject restartButton;

    private void Start()
    {
        submitButton.onClick.AddListener(SubmitScore);
    }

    public void ShowFinalScore(int score)
    {
        finalScoreText.text = "Final Score: " + score;
    }

    void SubmitScore()
    {
        string playerName = nameInputField.text;
        int score = ScoreManager.Instance.score;

        if (!string.IsNullOrEmpty(playerName))
        {
            LeaderboardManager.Instance.AddEntry(playerName, score);
            DisplayLeaderboard();
            submitButton.interactable = false; // One Submit

            restartButton.SetActive(true);
        }
    }

    void DisplayLeaderboard()
    {
        leaderboardText.text = "Top Scores:\n";
        foreach (var entry in LeaderboardManager.Instance.GetTopScores())
        {
            leaderboardText.text += $"{entry.playerName}: {entry.score}\n";
        }
    }
}
