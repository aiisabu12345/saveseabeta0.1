using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{
    public GameObject uiObject; // ���������Ѻ�к� GameObject UI ����ͧ�������ʴ�

    // ������Դ��ê�
    void OnCollisionEnter(Collision collision)
    {
        // ������Դ��ê��Ѻ����
        if (collision.gameObject.CompareTag("Player")) // �������� GameObject �����ҵ�ͧ��������� UI �� tag �� "Player"
        {
            // �ʴ� UI
            ShowUI();
        }
    }

    // �ѧ��ѹ����Ѻ�ʴ� UI
    public void ShowUI()
    {
        uiObject.SetActive(true); // �Դ��ҹ GameObject UI
        Time.timeScale = 0;
    }

    // �ѧ��ѹ����Ѻ��͹ UI
    public void HideUI()
    {
        uiObject.SetActive(false); // �Դ��ҹ GameObject UI
        Time.timeScale = 1;
    }
}
