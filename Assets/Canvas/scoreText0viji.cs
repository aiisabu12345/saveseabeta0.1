using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scoreText0viji : MonoBehaviour
{
    public TextMeshProUGUI scoreText1;
    public GameObject panel;
    public int score;

    public Sell sell;

    public Button button1;
    public Button button2;

    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;

    public int price1 = 30;
    public int price2 = 40;

    public int shark = 0;
    public int tako = 0;


    public void OpenUi()
    {

        shark = PlayerPrefs.GetInt("shark",0);

        tako = PlayerPrefs.GetInt("tako",0);

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
        PlayerPrefs.SetInt("shark",1);
        check();
    }

    public void buy2()
    {
        usescore(price2);
        PlayerPrefs.SetInt("tako",1);
        check();
    }


    public void check()
    {
        shark = PlayerPrefs.GetInt("shark",0);

        tako = PlayerPrefs.GetInt("tako",0);

        if(price1 > score)
        {
            button1.interactable = false;
        }
        else if(shark != 1)
        {
            button1.interactable = true;
        }

        if(price2 > score)
        {
            button2.interactable = false;
        }
        else if(tako != 1)
        {
            button2.interactable = true;
        }

        if(shark == 1)
        {
            text1.text = "SOLDOUT";
            button1.interactable = false;
        }

        if(tako == 1)
        {
            text2.text = "SOLDOUT";
            button2.interactable = false;
        }

    }
}
