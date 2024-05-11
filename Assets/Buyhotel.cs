using UnityEngine;
using UnityEngine.UI;

public class Buyhotel : MonoBehaviour
{
    public Text scoreText; // คะแนนของเราที่โชว์
    public Text scoreToRemoveText; // ไว้ใช้กับ ราคา ที่ต้องการโชว์
    public Button upgradeButton; // button กดซื้อ

    int score;
    int scoreToRemove = 5;

    void Awake()
    {
        score = PlayerPrefs.GetInt("Score", 0);
       
        scoreText.text = "Score: " + score.ToString();
        scoreToRemoveText.text = "price : " + scoreToRemove.ToString();
        if(Playerupgradevalue.alreadybuyhotel)
        {
            Interact();
        }
    }

     void Update()
    {
        score = PlayerPrefs.GetInt("Score", 0);
        if (score < scoreToRemove)
        {
            upgradeButton.interactable = false;
        }
    }

    
    void UpdateScore(int newScore)
    {
        
        scoreText.text = "Score: " + newScore.ToString();

    }

    public void Interact()
    {
        upgradeButton.interactable = false; 
        scoreToRemoveText.text = "SOLD OUT";
    }
    
    void SaveScore(int score)
    {
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();
    }

    public void buy()
    {
       
        score = PlayerPrefs.GetInt("Score", 0);
        
        int newScore = score - scoreToRemove;

        SaveScore(newScore);

        UpdateScore(newScore);

        Interact();

        Playerupgradevalue.alreadybuyhotel = true;   
    }
}
