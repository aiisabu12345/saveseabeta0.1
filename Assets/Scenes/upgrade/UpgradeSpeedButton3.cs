using UnityEngine;
using UnityEngine.UI;

public class UpgradeSpeedButton3 : MonoBehaviour
{
    public WaterBoat waterBoat; // Reference to the WaterBoat script
    public Text scoreText; // Reference to the UI text displaying the current score
    public Text scoreToRemoveText; // Reference to the UI text displaying the score to remove
    public Button upgradeButton; // Reference to the upgrade button

    private int upgradeRound = 0;

    void Start()
    {
        // Load score and scoreToRemove from PlayerPrefs
        int score = PlayerPrefs.GetInt("Score", 0);
        int scoreToRemove = PlayerPrefs.GetInt("ScoreToRemove", 0);

        // Display score and scoreToRemove
        scoreText.text = "Score: " + score.ToString();
        scoreToRemoveText.text = "price : " + scoreToRemove.ToString();

        // Check if score is less than or equal to 10 to disable the button initially
        if (score <= scoreToRemove)
        {
            upgradeButton.interactable = false;
        }
    }

    // Method to update the displayed score and enable/disable the button based on the score
    void UpdateScore(int newScore, int newScoreToRemove)
    {
        // Display updated score and scoreToRemove
        scoreText.text = "Score: " + newScore.ToString();
        scoreToRemoveText.text = "price : " + newScoreToRemove.ToString();

        // Enable/disable the button based on the score
        if (newScore <= newScoreToRemove)
        {
            upgradeButton.interactable = false;
        }
        else
        {
            upgradeButton.interactable = true;
        }
    }

    // Method to save the score and scoreToRemove to PlayerPrefs
    void SaveScore(int score, int scoreToRemove)
    {
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.SetInt("ScoreToRemove", scoreToRemove);
        PlayerPrefs.Save();
    }

    public void UpgradeSpeed()
    {
        // Load score and scoreToRemove from PlayerPrefs
        int score = PlayerPrefs.GetInt("Score", 0);
        int scoreToRemove = PlayerPrefs.GetInt("ScoreToRemove", 0);

        // Calculate new score and new scoreToRemove
       int newScore = score - scoreToRemove;
        int newScoreToRemove = (scoreToRemove + 40) ;

        // Save updated score and scoreToRemove
       SaveScore(newScore, newScoreToRemove);

       UpdateScore(newScore, newScoreToRemove);

        // Increase speed by 1 unit
        waterBoat.MaxSpeed += 1f;
        // Save the new speed to PlayerPrefs
        PlayerPrefs.SetFloat("Speed", waterBoat.MaxSpeed);

        // Increment upgradeRound for the next round
        upgradeRound++;
    }

    // Method to be called externally to deduct score
    public void DeductScore(int amount)
    {
        int score = PlayerPrefs.GetInt("Score", 0);
        score -= amount;
        SaveScore(score, PlayerPrefs.GetInt("ScoreToRemove", 0));
        UpdateScore(score, PlayerPrefs.GetInt("ScoreToRemove", 0));
    }
}
