using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    public TMP_Text currentRoomText;
    public GameObject player;
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController != null && playerController.currentRoom != null)
        {
            // แสดงชื่อห้องใน TextMeshPro
            currentRoomText.text = playerController.currentRoom.name;
        }
    }
}
