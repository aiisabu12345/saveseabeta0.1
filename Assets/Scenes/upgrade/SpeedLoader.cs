using UnityEngine;

public class SpeedLoader : MonoBehaviour
{
    public WaterBoat waterBoat;
    private void Start()
    {
        // Check if the speed key exists in PlayerPrefs
        if (PlayerPrefs.HasKey("Speed"))
        {
            // Retrieve the speed value from PlayerPrefs
            float Maxspeed = PlayerPrefs.GetFloat("Speed");
            Debug.Log("Speed retrieved from PlayerPrefs: " + Maxspeed);

            // ทำสิ่งที่คุณต้องการกับค่า speed ที่ได้รับ เช่น นำไปใช้กับวัตถุในเกม
        }
        else
        {
            Debug.LogWarning("Speed key not found in PlayerPrefs.");
            // Handle the case where the speed key is not found, such as using a default speed value
        }
    }
}