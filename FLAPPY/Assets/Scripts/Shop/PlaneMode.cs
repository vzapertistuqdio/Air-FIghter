using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaneMode : MonoBehaviour,IShopMode
{
    //private Player player;
    //[SerializeField] private GameObject playerObj;

    private GameObject plane;

    private bool IsNulled = false;

    private int ArraySize;

    public void Display(int id)
    {
     
        SetToStartArray();
        ArraySize = GetArraySizeForThis();
        GameObject displayItem = GameObject.FindWithTag("DisplayItem");
        if (plane == null)
        {
            plane = Instantiate(Shop.GetInstance().GetPlane(id).planeObject);
            plane.transform.localScale = new Vector2(1, 1);
        }
        plane.transform.position = displayItem.transform.position;
    }

    public int GetArraySize()
    {
        return ArraySize;
    }

    public int GetShowItemCost(int id)  //Получает цену отображаемого предмета
    {
        int cost = Shop.GetInstance().GetPlane(id).Cost;
        return cost;
    }

    public void OnEquipClick(int collectionID)
    {
      Player.GetInstance().SetPlane(Shop.GetInstance().GetPlane(collectionID));
       PlayerPrefs.SetInt("CurrentPlane", Shop.GetInstance().GetPlane(collectionID).ID);      
    }

    public int GetShowItem(int id)  //Получает цену отображаемого предмета TODOOOO
    {
        int plane = Shop.GetInstance().GetPlane(id).ID;
        return plane;
    }


    private void Start()
    {
        //player = Player.GetInstance();
       // Debug.Log(player);
    }
    private void Update()
    {

    }

    

    private void SetToStartArray()
    {
        if (IsNulled == false)
        {
            Shop.GetInstance().SetCurrentShowId(0);
            IsNulled = true;
        }
    }

    private int GetArraySizeForThis()
    {
        return Shop.GetInstance().GetSizeCollection("PlanesCollection");
    }

  

    

    public void DisplayParameters(int id, Text text)
    {
        text.text = "НАЗВАНИЕ: " + Shop.GetInstance().GetPlane(id).Name + "\nУРОН: " + Shop.GetInstance().GetPlane(id).Damage + "\nБРОНЯ: " + Shop.GetInstance().GetPlane(id).Armor + "\nСТОИМОСТЬ: " + Shop.GetInstance().GetPlane(id).Cost;
    }

    public void DestroyDisplayedItem()
    {
        Destroy(plane);
    }
}
