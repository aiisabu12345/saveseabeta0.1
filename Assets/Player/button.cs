using UnityEngine;
using UnityEngine.EventSystems;

public class button : MonoBehaviour
{
    public WaterBoat waterBoat; // อ้างอิงไปยังสคริปต์ WaterBoat

    public void OnMoveForwardButtonClick()
    {
        waterBoat.StartMovingForward(); // เรียกใช้งานเมท็อด MoveForward() ในสคริปต์ WaterBoat เมื่อคลิกปุ่มเคลื่อนที่ข้างหน้า
    }

    public void OnMoveBackwardButtonClick()
    {
        waterBoat.MoveBackward(); // เรียกใช้งานเมท็อด MoveBackward() ในสคริปต์ WaterBoat เมื่อคลิกปุ่มถอยหลัง
    } 

    public void OnSteerLeftButtonClick()
    {
        waterBoat.SteerLeft(); // เรียกใช้งานเมท็อด SteerLeft() ในสคริปต์ WaterBoat เมื่อคลิกปุ่มหมุนซ้าย
    }

    public void OnSteerRightButtonClick()
    {
        waterBoat.SteerRight(); // เรียกใช้งานเมท็อด SteerRight() ในสคริปต์ WaterBoat เมื่อคลิกปุ่มหมุนขวา
    }
    public void OnStopButtonClick()
    {
        waterBoat.StopMoving(); // เรียกใช้งานเมท็อด Stop() ในสคริปต์ WaterBoat เมื่อคลิกปุ่มหยุด
    }

    public void stopad()
    {
        waterBoat.StopAD();
    }
}
