using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Room currentRoom;
    public Camera cam;
    public UIManager uiManager;
    public StatusManager statusManager;
    public bool canWalk;

    void Update()
    {
        if (canWalk)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                StartCoroutine(WalkToDoor(currentRoom.upDoor.position,currentRoom.up));                           
            }               
            if (Input.GetKeyDown(KeyCode.S))
            {
                StartCoroutine(WalkToDoor(currentRoom.downDoor.position,currentRoom.down));
            }                
            if (Input.GetKeyDown(KeyCode.A))
            {
                StartCoroutine(WalkToDoor(currentRoom.leftDoor.position,currentRoom.left));
            }            
            if (Input.GetKeyDown(KeyCode.D))
            {
                StartCoroutine(WalkToDoor(currentRoom.rightDoor.position,currentRoom.right));
            }
        }        
    }

    IEnumerator MoveToRoom(Room nextRoom)
    {
        if (nextRoom != null)
        {
            uiManager.FadeOutIn();
            currentRoom = nextRoom;
            transform.position = currentRoom.spawnPoint.position;
            yield return new WaitForSeconds(0.3f);
            MoveCamera moveCam = cam.GetComponent<MoveCamera>();
            if (moveCam != null)
            {
                moveCam.currentRoom = nextRoom;              
                moveCam.MoveToCam1();
                uiManager.OpenButton2();
            }
            //Update status
            statusManager.DecreaseHunger(statusManager.hungerDecreasePerRoom);
        }
        else
        {
            Debug.Log("Can't go that way!");
            StartCoroutine(WalkBack( currentRoom.spawnPoint.position));
        }
    }

    IEnumerator WalkToDoor(Vector3 target, Room direction)
    {
        canWalk = false;
        float speed = 5f;
        while (Vector3.Distance(transform.position, target) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            yield return null;
        }
        canWalk = true;
        StartCoroutine(MoveToRoom(direction));
    }

    IEnumerator WalkBack(Vector3 target)
    {
        canWalk = false;
        float speed = 5f;
        while (Vector3.Distance(transform.position, target) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            yield return null;
        }
        canWalk = true;
    }
}
