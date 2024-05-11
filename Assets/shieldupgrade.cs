using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class shieldupgrade : MonoBehaviour
{
    public TextMeshProUGUI buttontext;
    public Text scoreText; // คะแนนของเราที่โชว์
    public Text scoreToRemoveText; // ไว้ใช้กับ ราคา ที่ต้องการโชว์
    public Button upgradeButton; // button กดซื้อ

    private int upgradeRound;

    int score;
    int scoreToRemove;

    void Awake()
    {
       
        score = PlayerPrefs.GetInt("Score", 0);
        scoreToRemove = PlayerPrefs.GetInt("ScoreToRemoveShield", 0);

       
        scoreText.text = "Score: " + score.ToString();
        scoreToRemoveText.text = "price : " + scoreToRemove.ToString();

        UpgradeLevel();

        if(upgradeRound == 10)
        {
            upgradeButton.interactable = false;
            buttontext.text = "Lv." + upgradeRound.ToString() + " MAX";

        }
    }

    void Update()
    {
        score = PlayerPrefs.GetInt("Score", 0);
        if (score < scoreToRemove  && upgradeRound != 10)
        {
            upgradeButton.interactable = false;
        }
    }

    
    void UpdateScore(int newScore, int newScoreToRemove)
    {
        
        scoreText.text = "Score: " + newScore.ToString();
        scoreToRemoveText.text = "price : " + newScoreToRemove.ToString();

       
        if (newScore < newScoreToRemove)
        {
            upgradeButton.interactable = false;
        }
        else
        {
            upgradeButton.interactable = true;
        }
    }

    
    void SaveScore(int score, int scoreToRemove)
    {
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.SetInt("ScoreToRemoveShield", scoreToRemove);
        PlayerPrefs.Save();
    }

    public void UpgradeShield()
    {
       
        score = PlayerPrefs.GetInt("Score", 0);
        scoreToRemove = PlayerPrefs.GetInt("ScoreToRemoveShield", 0);

        
        int newScore = score - scoreToRemove;
        int newScoreToRemove = (scoreToRemove + 40); // +40 คือราคาที่จะเพิ่มขึ้นเรื่อยๆ

        
        SaveScore(newScore, newScoreToRemove);

        UpdateScore(newScore, newScoreToRemove);

        // การปรับmaxspeed
        Playerupgradevalue.cd -= 0.5f;

        upgradeRound = PlayerPrefs.GetInt("upgradeshield",0);
        // Increment upgradeRound for the next round
        upgradeRound++;

        PlayerPrefs.SetInt("upgradeshield",upgradeRound);

        UpgradeLevel();
        if(upgradeRound == 10)
        {
            upgradeButton.interactable = false;
            buttontext.text = "Lv." + upgradeRound.ToString() + " MAX";

        }
    }

    public void UpgradeLevel()
    {
        upgradeRound = PlayerPrefs.GetInt("upgradeshield",0);
        buttontext.text = "Lv." + upgradeRound.ToString() + " UPGRADE";
    }

    // Method to be called externally to deduct score
    public void DeductScore(int amount)
    {
        score = PlayerPrefs.GetInt("Score", 0);
        score -= amount;
        SaveScore(score, PlayerPrefs.GetInt("ScoreToRemoveShield", 0));
        UpdateScore(score, PlayerPrefs.GetInt("ScoreToRemoveShield", 0));
    }
}
