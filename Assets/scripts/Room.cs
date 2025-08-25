using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [Header("Room Settings")]
    public Room up;
    public Room down;
    public Room left;
    public Room right;   
    public Transform upDoor, downDoor, leftDoor, rightDoor,spawnPoint;
    public Vector3 position => transform.position;

    [Header("Detection Settings")]
    public float detectDistance = 10f; // ������ҧ�����ҧ��ͧ (��ͧ�ç�Ѻ spacing ���س�� spawn)

    [Header("Camera Transform")]
    public Transform cam1;
    public Transform cam2;
    public Transform cam3;

    // ����ͧ���¡� Start ����
    // void Start() { AutoLinkNeighbors(); }

    public void AutoLinkNeighbors()
    {
        Room[] allRooms = FindObjectsOfType<Room>();

        foreach (Room other in allRooms)
        {
            if (other == this) continue;

            Vector3 diff = other.position - this.position;

            // ��
            if (Mathf.Abs(diff.x) < 1f && diff.z > 0 && Mathf.Abs(diff.z - detectDistance) < 1f)
                up = other;

            // ��ҧ
            if (Mathf.Abs(diff.x) < 1f && diff.z < 0 && Mathf.Abs(diff.z + detectDistance) < 1f)
                down = other;

            // ����
            if (Mathf.Abs(diff.z) < 1f && diff.x < 0 && Mathf.Abs(diff.x + detectDistance) < 1f)
                left = other;

            // ���
            if (Mathf.Abs(diff.z) < 1f && diff.x > 0 && Mathf.Abs(diff.x - detectDistance) < 1f)
                right = other;
        }
    }
}

