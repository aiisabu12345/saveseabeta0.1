using UnityEngine;

public class IncrementSpeedButton : MonoBehaviour
{
    public WaterBoat waterBoat; // Reference to the WaterBoat script

    public void IncrementSpeed()
    {
        // Increment speed by 1 unit
        waterBoat.MaxSpeed += 2f;
        // Save the new speed to PlayerPrefs
        PlayerPrefs.SetFloat("Speed", waterBoat.MaxSpeed);
    }
}
