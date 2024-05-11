using UnityEngine;
using UnityEngine.UI;

public class ButtonResetScoreToRemove : MonoBehaviour
{
    //public Text scoreToRemoveText; // Reference to the UI text displaying the score to remove

    public Sell sell;

    public void ResetScoreToRemove()
    {
        if(Playerupgradevalue.firstrun == 0)
        {
               PlayerPrefs.SetInt("ScoreToRemoveSpeed", 40);
               PlayerPrefs.SetInt("ScoreToRemoveHp", 40);
               PlayerPrefs.SetInt("ScoreToRemoveShield", 40);
               PlayerPrefs.SetInt("ScoreToRemoveShoot", 40);
               PlayerPrefs.Save();
               Playerupgradevalue.firstrun++;
        }
    }
}
