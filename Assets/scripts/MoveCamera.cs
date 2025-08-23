using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Room currentRoom;

    public void MoveToCam1()
    {
        transform.position = currentRoom.cam1.transform.position;
        transform.rotation = currentRoom.cam1.transform.rotation;
    }

    public void MoveToCam2()
    {
        transform.position = currentRoom.cam2.transform.position;
        transform.rotation = currentRoom.cam2.transform.rotation;
    }

    public void MoveToCam3()
    {
        transform.position = currentRoom.cam3.transform.position;
        transform.rotation = currentRoom.cam3.transform.rotation;
    }
}
