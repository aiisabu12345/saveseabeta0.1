using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreText : MonoBehaviour
{
    public TextMeshProUGUI scoreText1;
    public GameObject panel;
    public int score;

    public Sell sell;

    public Button button1;
    public Button button2;
    public Button button3;

    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    public TextMeshProUGUI text3;

    public int price1 = 30;
    public int price2 = 40;
    public int price3 = 50;

    public int hotelincome1 = 0;
    public int hotelincome2 = 0;
    public int hotelincome3 = 0;

    public void OpenUi()
    {
        hotelincome1 = PlayerPrefs.GetInt("income1",0);

        hotelincome2 = PlayerPrefs.GetInt("income2",0);

        hotelincome3 = PlayerPrefs.GetInt("income3",0);

        panel.SetActive(true);
        sell = GameObject.FindObjectOfType<Sell>();
        score = sell.score;
        updatescore();

        check();
    }

    public void CloseUi()
    {
        panel.SetActive(false);
    }

    public void updatescore()
    {
        scoreText1.text = "score : " + score.ToString();
    }

    public void usescore(int use)
    {
        score -= use;
        updatescore();

        sell.usescore(use);
    }

    public void buy1()
    {
        usescore(price1);
        PlayerPrefs.SetInt("income1",1);
        check();
    }

    public void buy2()
    {
        usescore(price2);
        PlayerPrefs.SetInt("income2",1);
        check();
    }

    public void buy3()
    {
        usescore(price3);
        PlayerPrefs.SetInt("income3",1);
        check();
    }


    public void check()
    {
        hotelincome1 = PlayerPrefs.GetInt("income1",0);

        hotelincome2 = PlayerPrefs.GetInt("income2",0);

        hotelincome3 = PlayerPrefs.GetInt("income3",0);

        if(price1 > score)
        {
            button1.interactable = false;
        }
        else if(hotelincome1 != 1)
        {
            button1.interactable = true;
        }
        

        if(price2 > score)
        {
            button2.interactable = false;
        }
        else if(hotelincome2 != 1)
        {
            button2.interactable = true;
        }

        if(price3 > score)
        {
            button3.interactable = false;
        }
        else if(hotelincome3 != 1)
        {
            button3.interactable = true;
        }

        if(hotelincome1 == 1)
        {
            text1.text = "SOLDOUT";
            button1.interactable = false;
        }

        if(hotelincome2 == 1)
        {
            text2.text = "SOLDOUT";
            button2.interactable = false;
        }

        if(hotelincome3 == 1)
        {
            text3.text = "SOLDOUT";
            button3.interactable = false;
        }
    }
}
