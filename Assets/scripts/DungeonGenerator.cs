using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
    [Header("Dungeon Settings")]
    public GameObject[] roomPrefabs;   // prefab ��ͧ
    public GameObject startRoom;
    public int rows = 3;               // �ӹǹ�� (Z)
    public int cols = 10;              // �ӹǹ��ͧ����� (X)
    public float roomSpacingX = 15f;   // ������ҧ�ǹ͹ (X)
    public float roomSpacingZ = 15f;   // ������ҧ���֡ (Z)

    //public float detectDistance=15f;

    [Header("Spawn Settings")]
    public Transform startPoint;       // �ش��������ҧ��ͧ (������º�)

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
            // ��Ѻ���᡹ Z (᷹ Y ���)
            Vector3 rowStart = startPos - new Vector3(0, 0, row * roomSpacingZ);

            Vector3 spawnPos = rowStart;

            for (int col = 0; col < cols; col++)
            {
                // ���� prefab
                GameObject roomPrefab = roomPrefabs[Random.Range(0, roomPrefabs.Length)];

                // ���ҧ��ͧ
                Instantiate(roomPrefab, spawnPos, Quaternion.identity);

                // ��Ѻ价ҧ���� (᡹ X)
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
