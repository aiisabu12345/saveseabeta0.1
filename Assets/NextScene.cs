using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// เพิ่ม using statement เพื่อใช้งาน Tweening library ที่คุณเลือก


public class NextScene : MonoBehaviour
{
    public Text scoreText;

    void Start()
    {
        // ดึงค่า score จาก PlayerPrefs
        int score = PlayerPrefs.GetInt("Score", 0);
        
        // แสดงค่า score ใน Text UI
        scoreText.text = "Score: " + score.ToString();

        // เริ่ม Coroutine เพื่อทำ Animation
       // StartCoroutine(AnimateScore(score));
    }

     IEnumerator AnimateScore(int targetScore)
    {
        int currentScore = 0;

        // Loop เพื่อเปลี่ยนคะแนนแต่ละครั้ง
        while (currentScore < targetScore)
        {
            currentScore++; // เพิ่มคะแนนทีละหนึ่ง

            // อัพเดทค่าคะแนนใน Text UI
            scoreText.text = "Score: " + currentScore.ToString();

            // ใช้ Tweening library เพื่อทำ Animation
            // ตัวอย่างเช่น LeanTween
            LeanTween.scale(scoreText.rectTransform, Vector3.one * 1.2f, 0.1f).setEase(LeanTweenType.easeOutQuad);
            yield return new WaitForSeconds(0.01f);

            // ใช้ Tweening library เพื่อทำ Animation
            // ตัวอย่างเช่น LeanTween
            LeanTween.scale(scoreText.rectTransform, Vector3.one, 0.1f).setEase(LeanTweenType.easeOutQuad);
            yield return new WaitForSeconds(0.01f);
        }
    } 
}
