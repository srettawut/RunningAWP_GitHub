using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusManager : MonoBehaviour
{
    public Slider hungerbar;
    public int maxHunger = 100;
    public int currentHunger;
    public int hungerDecreasePerRoom = 5;
    // Start is called before the first frame update
    void Start()
    {
        currentHunger = maxHunger;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DecreaseHunger(int amount)
    {
        currentHunger -= amount;
        if (currentHunger < 0)
        {
            currentHunger = 0;
        }
        UpdateUI();
    }
    void UpdateUI()
    {
        hungerbar.value = currentHunger;
    }

}
