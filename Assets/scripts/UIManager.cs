using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    [Header("CHANGE CAM BUTTON")]
    public GameObject camButton1;
    public GameObject camButton2;
    public GameObject camButton3;


    public void OpenButton1()
    {
        camButton1.SetActive(true);
        camButton2.SetActive(false);
        camButton3.SetActive(false);
    }

    public void OpenButton2()
    {
        camButton1.SetActive(false);
        camButton2.SetActive(true);
        camButton3.SetActive(false);
    }

    public void OpenButton3()
    {
        camButton1.SetActive(false);
        camButton2.SetActive(false);
        camButton3.SetActive(true);
    }
}
