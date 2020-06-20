using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryInitialize : MonoBehaviour
{
    private Inventory inventory;
    private void Start()
    {
        inventory = Inventory.GetInstance();
        inventory.Add(101);
        inventory.Add(201);
        inventory.Save();
        if (PlayerPrefs.GetInt("CurrentPlane")==0)
            PlayerPrefs.SetInt("CurrentPlane", 101);
        if (PlayerPrefs.GetInt("CurrentPilot") == 0)
            PlayerPrefs.SetInt("CurrentPilot", 201);
        

    }
   

}
