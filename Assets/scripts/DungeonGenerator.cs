using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
    [Header("Dungeon Settings")]
    public GameObject[] roomPrefabs;   // prefab ห้อง
    public GameObject startRoom;
    public int rows = 3;               // จำนวนแถว (Z)
    public int cols = 10;              // จำนวนห้องต่อแถว (X)
    public float roomSpacingX = 15f;   // ระยะห่างแนวนอน (X)
    public float roomSpacingZ = 15f;   // ระยะห่างแนวลึก (Z)

    //public float detectDistance=15f;

    [Header("Spawn Settings")]
    public Transform startPoint;       // จุดเริ่มสร้างห้อง (มุมซ้ายบน)

    void Start()
    {
        GenerateDungeon();
        LinkAllRooms();
    }

    void GenerateDungeon()
    {
        Vector3 startPos = startPoint != null ? startPoint.position : Vector3.zero;

        for (int row = 0; row < rows; row++)
        {
            // ขยับตามแกน Z (แทน Y เดิม)
            Vector3 rowStart = startPos - new Vector3(0, 0, row * roomSpacingZ);

            Vector3 spawnPos = rowStart;

            for (int col = 0; col < cols; col++)
            {
                // สุ่ม prefab
                GameObject roomPrefab = roomPrefabs[Random.Range(0, roomPrefabs.Length)];

                // สร้างห้อง
                Instantiate(roomPrefab, spawnPos, Quaternion.identity);

                // ขยับไปทางซ้าย (แกน X)
                spawnPos.x += roomSpacingX;
            }
        }
    }

    void LinkAllRooms()
    {
        Room[] allRooms = FindObjectsOfType<Room>();
        foreach (Room room in allRooms)
        {
            room.AutoLinkNeighbors();
        }
    }
}
