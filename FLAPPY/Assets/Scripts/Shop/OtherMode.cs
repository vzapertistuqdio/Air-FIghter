using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OtherMode : MonoBehaviour,IShopMode
{

    private bool IsNulled = false;

    private int ArraySize;

    private GameObject buff;

    public void Display(int id)
    {
        SetToStartArray();
        ArraySize = GetArraySizeForThis();
        GameObject displayItem = GameObject.FindWithTag("DisplayItem");
        if (buff == null)
        {
           buff = Instantiate(Shop.GetInstance().GetBuff(id).buffObject);
            buff.transform.localScale = new Vector2(1, 1);
        }
        buff.transform.position = displayItem.transform.position;
    }

    private int GetArraySizeForThis()
    {
        return Shop.GetInstance().GetSizeCollection("BuffsCollection");
    }

    public int GetArraySize()
    {
        return ArraySize;
    }

    public void DisplayParameters(int id, Text text)
    {
        text.text = "НАЗВАНИЕ: " + Shop.GetInstance().GetBuff(id).Name+ "\nСТОИМОСТЬ: " + Shop.GetInstance().GetBuff(id).Cost;
        
    }

    public int GetShowItemCost(int id)
    {
        int cost = Shop.GetInstance().GetBuff(id).Cost;
        return cost;
    }


    public int GetShowItem(int id)  
    {
        int buff= Shop.GetInstance().GetBuff(id).ID;
        return buff;
    }

    private void SetToStartArray()
    {
        if (IsNulled == false)
        {
            Shop.GetInstance().SetCurrentShowId(0);
            IsNulled = true;
        }
    }
    public void OnEquipClick(int collectionID)
    {

    }

    public void DestroyDisplayedItem()
    {
        Destroy(buff);
    }
}
