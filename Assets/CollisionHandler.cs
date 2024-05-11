using UnityEngine;
using UnityEngine.UI;

public class CollisionHandler : MonoBehaviour
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

    // เมื่อออกจากการชน
    void OnCollisionExit(Collision collision)
    {
        // เช็คว่าออกจากการชนกับอะไร
        if (collision.gameObject.CompareTag("Player")) // สมมติว่า GameObject ที่เราต้องการให้โชว์ UI มี tag เป็น "Player"
        {
            // ซ่อน UI
            HideUI();
        }
    }

    // ฟังก์ชันสำหรับแสดง UI
    void ShowUI()
    {
        uiObject.SetActive(true); // เปิดใช้งาน GameObject UI
    }

    // ฟังก์ชันสำหรับซ่อน UI
    void HideUI()
    {
        uiObject.SetActive(false); // ปิดใช้งาน GameObject UI
    }
}
