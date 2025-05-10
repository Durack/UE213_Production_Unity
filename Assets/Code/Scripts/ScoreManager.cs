using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int score = 0;
    public float comboMultiplier = 1.0f;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI comboText;

    public float comboResetTime = 5f; // Time window before combo resets
    private float comboTimer = 0f;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateUI();
    }

    void Update()
    {
        // If combo is greater than base and timer has passed, reset the combo
        if (comboMultiplier > 1.0f)
        {
            comboTimer += Time.deltaTime;
            if (comboTimer >= comboResetTime)
            {
                ResetCombo();
            }
        }
    }

    public void AddScore(int baseAmount)
    {
        comboMultiplier += 0.2f;
        comboMultiplier = Mathf.Min(comboMultiplier, 10.0f);

        int addedScore = Mathf.RoundToInt(baseAmount * comboMultiplier);
        score += addedScore;

        comboTimer = 0f; // Reset timer when player collects stuff

        UpdateUI();
    }

    public void ResetCombo()
    {
        comboMultiplier = 1.0f;
        comboTimer = 0f;
        UpdateUI();
    }
    public void DecreaseCombo()
    {
        comboMultiplier -= 0.2f;
        comboMultiplier = Mathf.Max(comboMultiplier, 1.0f);
        UpdateUI();
    }

    private void UpdateUI()
    {
        scoreText.text = "" + score;
        comboText.text = "X" + comboMultiplier.ToString("0.0");
    }
}
