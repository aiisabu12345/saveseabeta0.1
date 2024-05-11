using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{
    public GameObject uiObject; // ตัวแปรสำหรับระบุ GameObject UI ที่ต้องการให้แสดง

    // เมื่อเกิดการชน
    void OnCollisionEnter(Collision collision)
    {
        // เช็คว่าเกิดการชนกับอะไร
        if (collision.gameObject.CompareTag("Player")) // สมมติว่า GameObject ที่เราต้องการให้โชว์ UI มี tag เป็น "Player"
        {
            // แสดง UI
            ShowUI();
        }
    }

    // ฟังก์ชันสำหรับแสดง UI
    public void ShowUI()
    {
        uiObject.SetActive(true); // เปิดใช้งาน GameObject UI
        Time.timeScale = 0;
    }

    // ฟังก์ชันสำหรับซ่อน UI
    public void HideUI()
    {
        uiObject.SetActive(false); // ปิดใช้งาน GameObject UI
        Time.timeScale = 1;
    }
}
