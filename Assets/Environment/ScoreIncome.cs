using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreIncome : MonoBehaviour
{
    public Sell sell;

    public int hotelincome1 = 0;
    public int hotelincome2 = 0;
    public int hotelincome3 = 0;

    public int income1 = 500;
    public int income2 = 1500;
    public int income3 = 2500;
    void Start()
    {
        sell = GameObject.FindObjectOfType<Sell>();

        hotelincome1 = PlayerPrefs.GetInt("income1",0);

        hotelincome2 = PlayerPrefs.GetInt("income2",0);

        hotelincome3 = PlayerPrefs.GetInt("income3",0);

        if(hotelincome1 == 1)
        {
            sell.addscore(income1);
        }

        if(hotelincome2 == 1)
        {
            sell.addscore(income2);
        }

        if(hotelincome3 == 1)
        {
            sell.addscore(income3);
        }
    }
}
