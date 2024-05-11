using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Sell : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
   // [SerializeField] Text scoreText;
    public int count = 0;
    public int score = 0;
    int tem;

    public PlayerStatus playerstatus;

    void Awake()
    {
        score = PlayerPrefs.GetInt("Score", 0); // Default value 1000 if no previous score exists
        playerstatus = GameObject.FindObjectOfType<PlayerStatus>();
        UpdateScoreText();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("mini"))
        {
            addscore(10);
            Destroy(other.gameObject);
            count++;
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("medium"))
        {
            addscore(20);
            Destroy(other.gameObject);
            count++;
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("big"))
        {
            addscore(30);
            Destroy(other.gameObject);
            count++;
        }
    }

    public void addscore(int add)
    {
        score += add;
        UpdateScoreText();
    }

    public void usescore(int add)
    {
        score -= add;
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        scoreText.text = "Score : " + score.ToString();
    }

    // Save the score before changing scenes
    void OnDestroy()
    {
        if (playerstatus.isgameover)
        {
            score -= 500;
            
        }
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();
    }

    // Method to reset score
    public void ResetScore()
    {
        score = 0;
        UpdateScoreText();
    }
}
