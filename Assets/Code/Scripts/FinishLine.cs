using UnityEngine;
using TMPro; // TextMeshPro UI element
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    public GameObject scorePanel; // UI panel to show score
    public TMP_Text scoreText; // Drag a TMP_Text 

    public void RestartLevel()
    {
        Time.timeScale = 1f; // Resume the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload scene
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Stop the car
            PathCreation.Examples.PathFollower pathFollower = other.GetComponent<PathCreation.Examples.PathFollower>();
            if (pathFollower != null)
            {
                pathFollower.speed = 0f;
                pathFollower.DisableInput();
                Time.timeScale = 0f;
            }

            // Show score panel
            if (scorePanel != null)
                scorePanel.SetActive(true);

            // Display score
            if (scoreText != null && ScoreManager.Instance != null)
            {
                scoreText.text = "Final Score: " + ScoreManager.Instance.score.ToString();
            }

            Debug.Log("Level finished");
        }
    }
}
