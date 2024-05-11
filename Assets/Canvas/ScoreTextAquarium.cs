using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreTextAquarium : MonoBehaviour
{
    public TextMeshProUGUI scoreText1;
    public GameObject panel;
    public int score;

    public Sell sell;

    public Button[] button;

    public TextMeshProUGUI[] text;

    public int[] price;

    public int[] Typecheck;

    public void OpenUi()
    {
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

    public void breeding(int a)
    {
        usescore(price[a]);
        int tem = PlayerPrefs.GetInt("Type" + a.ToString(),0);
        PlayerPrefs.SetInt("Type" + a.ToString(),tem + 1);
        check();
    }

    public void check()
    {
        for(int i = 0;i < 5;i++)
        {
            Typecheck[i] = PlayerPrefs.GetInt("Type" + i.ToString(),0);

            text[i].text = "FISH TYPE " + i.ToString() + " : " + Typecheck[i].ToString();

            if(price[i] > score)
            {
                button[i].interactable = false;
            }
            else
            {
                button[i].interactable = true;
            }
        }

    }
}
