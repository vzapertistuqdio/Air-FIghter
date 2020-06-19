using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PilotMode : MonoBehaviour,IShopMode
{
    private Player player = Player.GetInstance();

    private GameObject pilot;

    private bool IsNulled = false;

    private int ArraySize;
 

    public void Display(int id)
    {
       
        SetToStartArray();
        ArraySize = GetArraySizeForThis();
        GameObject displayItem = GameObject.FindWithTag("DisplayItem");
        if (pilot == null)
        {
            pilot = Instantiate(Shop.GetInstance().GetPilot(id).pilotObject);
            pilot.transform.localScale = new Vector2(2, 2);
        }
       pilot.transform.position = displayItem.transform.position;

    }

     public int GetArraySize()
    {
        return ArraySize;
    }

    public void DisplayParameters(int id, Text text)
    {
        text.text = "НАЗВАНИЕ: " + Shop.GetInstance().GetPilot(id).Name + "\nУДАЧА: " + Shop.GetInstance().GetPilot(id).Luck + "\nСТОИМОСТЬ: " + Shop.GetInstance().GetPilot(id).Cost;
    }

    public int GetShowItemCost(int id)  //Получает цену отображаемого предмета
    {
       int cost= Shop.GetInstance().GetPilot(id).Cost;
        return cost;
    }
    
    public int GetShowItem(int id)  //Получает цену отображаемого предмета TODOOOO
    {
        int pilot = Shop.GetInstance().GetPilot(id).ID;
        return pilot;
    }

    public void OnEquipClick(int collectionID)
    {
        player.SetPilot(Shop.GetInstance().GetPilot(collectionID));
        PlayerPrefs.SetInt("CurrentPilot", Shop.GetInstance().GetPilot(collectionID).ID);
    }

    private int GetArraySizeForThis()
    {
        return Shop.GetInstance().GetSizeCollection("PilotsCollection");
    }

    private void SetToStartArray()
    {
        if (IsNulled == false)
        {
            Shop.GetInstance().SetCurrentShowId(0);
            IsNulled = true;
        }
    }


  

    public void DestroyDisplayedItem()
    {
        Destroy(pilot);
    }
}
