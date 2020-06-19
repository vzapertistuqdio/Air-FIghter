using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IShopMode
{
    void Display(int id);
    int GetArraySize();
    void DisplayParameters(int id, Text text);
    int GetShowItemCost(int id);
    int GetShowItem(int id);
    void OnEquipClick(int collectionID);
    void DestroyDisplayedItem();

   
}
