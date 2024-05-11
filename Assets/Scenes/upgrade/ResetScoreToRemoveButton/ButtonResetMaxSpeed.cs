using UnityEngine;

public class ButtonResetMaxSpeed : MonoBehaviour
{
    public WaterBoat waterBoatPrefab;

    public void ResetMaxSpeed()
    {
        waterBoatPrefab.MaxSpeed = 5f; // กำหนดค่า MaxSpeed ให้กับ Prefab เป็น 5
       // waterBoatPrefab.SaveSpeed(); // บันทึกค่า MaxSpeed ลงใน PlayerPrefs
    }
}