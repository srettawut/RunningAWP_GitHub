using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Room currentRoom;
    private float yPos=1f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            MoveToRoom(currentRoom.up);
        if (Input.GetKeyDown(KeyCode.S))
            MoveToRoom(currentRoom.down);
        if (Input.GetKeyDown(KeyCode.A))
            MoveToRoom(currentRoom.left);
        if (Input.GetKeyDown(KeyCode.D))
            MoveToRoom(currentRoom.right);
    }

    void MoveToRoom(Room nextRoom)
    {
        if (nextRoom != null)
        {
            currentRoom = nextRoom;
            Vector3 targetPos = currentRoom.position;
            targetPos.y = yPos;
            transform.position = targetPos;
        }
        else
        {
            Debug.Log("Can't go that way!");
        }
    }
}
