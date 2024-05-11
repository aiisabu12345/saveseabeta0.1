using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reset : MonoBehaviour
{
    public Sell sell;
    // Start is called before the first frame update
    void Awake()
    {
        sell = GameObject.FindObjectOfType<Sell>();

        if(Playerupgradevalue.firstrun == 0)
        {
               PlayerPrefs.SetInt("Score", 0);
               PlayerPrefs.SetInt("income1", 0);
               PlayerPrefs.SetInt("income2", 0);
               PlayerPrefs.SetInt("income3", 0);
               PlayerPrefs.SetInt("shark", 0);
               PlayerPrefs.SetInt("tako", 0);
               PlayerPrefs.SetInt("Type0", 0);
               PlayerPrefs.SetInt("Type1", 0);
               PlayerPrefs.SetInt("Type2", 0);
               PlayerPrefs.SetInt("Type3", 0);
               PlayerPrefs.SetInt("Type4", 0);
               PlayerPrefs.SetInt("upgradespeed", 1);
               PlayerPrefs.SetInt("upgradeatk", 1);
               PlayerPrefs.SetInt("upgradehp", 1);
               PlayerPrefs.SetInt("upgradeshield", 1);
               PlayerPrefs.SetInt("ScoreToRemoveSpeed", 40);
               PlayerPrefs.SetInt("ScoreToRemoveHp", 40);
               PlayerPrefs.SetInt("ScoreToRemoveShield", 40);
               PlayerPrefs.SetInt("ScoreToRemoveShoot", 40);
               PlayerPrefs.Save();
               Playerupgradevalue.firstrun++;
               sell.ResetScore();
        }
    }
}
