using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Upgradeshootingbutton : MonoBehaviour
{
    public TextMeshProUGUI buttontext;
    public Text scoreText; // ��ṹ�ͧ��ҷ�����
    public Text scoreToRemoveText; // �����Ѻ �Ҥ� ����ͧ������
    public Button upgradeButton; // button ������

    private int upgradeRound;

    int score;
    int scoreToRemove;

    void Awake()
    {
       
        score = PlayerPrefs.GetInt("Score", 0);
        scoreToRemove = PlayerPrefs.GetInt("ScoreToRemoveShoot", 0);

       
        scoreText.text = "Score: " + score.ToString();
        scoreToRemoveText.text = "price : " + scoreToRemove.ToString();

        UpgradeLevel();
    }

    void Update()
    {
        score = PlayerPrefs.GetInt("Score", 0);
        if (score < scoreToRemove)
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
        PlayerPrefs.SetInt("ScoreToRemoveShoot", scoreToRemove);
        PlayerPrefs.Save();
    }

    public void UpgradeShoot()
    {
       
        score = PlayerPrefs.GetInt("Score", 0);
        scoreToRemove = PlayerPrefs.GetInt("ScoreToRemoveShoot", 0);

        
        int newScore = score - scoreToRemove;
        int newScoreToRemove = (scoreToRemove + 40); // +40 ����Ҥҷ�����������������

        
        SaveScore(newScore, newScoreToRemove);

        UpdateScore(newScore, newScoreToRemove);

        // ��û�Ѻmaxspeed
        Playerupgradevalue.damage += 10f;

        upgradeRound = PlayerPrefs.GetInt("upgradeatk",0);
        // Increment upgradeRound for the next round
        upgradeRound++;

        PlayerPrefs.SetInt("upgradeatk",upgradeRound);

        UpgradeLevel();
    }

    public void UpgradeLevel()
    {
        upgradeRound = PlayerPrefs.GetInt("upgradeatk",0);
        buttontext.text = "Lv." + upgradeRound.ToString() + " UPGRADE";
    }

    // Method to be called externally to deduct score
    public void DeductScore(int amount)
    {
        score = PlayerPrefs.GetInt("Score", 0);
        score -= amount;
        SaveScore(score, PlayerPrefs.GetInt("ScoreToRemoveShoot", 0));
        UpdateScore(score, PlayerPrefs.GetInt("ScoreToRemoveShoot", 0));
    }
}
