using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private static Inventory _inventory = new Inventory();

    private List<int> BoughtedItemID = new List<int>();

    private Inventory() { }

    public static Inventory GetInstance()
    {
        return _inventory;
    }

    public void Add(int id)
    {
        BoughtedItemID.Add(id);
     
    }
    public bool CheckItem(int itemID)
    {
        bool hasItem = false;
        List<int> itemsID = GetInventory();
        foreach(int id in itemsID)
        {
            if (itemID == id)
                hasItem = true;
        }
        return hasItem;       
    }

    public void Save()
    {
        foreach (int id in BoughtedItemID)
        {
            SavedInDatabase(id);
        }
       

    }
    public void Load()
    {
        LoadInventory();
        
    }

    private void Start()
    {
        _inventory = GetComponent<Inventory>();
        Load();
      
    }
    private void Update()
    {
   
        
    }

    private void SavedInDatabase(int id)
    {
        PlayerPrefs.SetString("Inventory",PlayerPrefs.GetString("Inventory") +" "+id.ToString());
    }
    private void LoadInventory()
    {
        string inventoryItems=PlayerPrefs.GetString("Inventory");
        string[] ids = inventoryItems.Split(new char[] { ' ' });
        for (int i = 0; i < ids.Length; i++)
        {
            int res;
            if(int.TryParse(ids[i], out res))
            {
                if (BoughtedItemID.Equals(int.Parse(ids[i]))==false)
                {
                    BoughtedItemID.Add(int.Parse(ids[i]));
                }
                
            }
          
        } 
    }
    private List<int> GetInventory()
    {
        List<int> itemIDs = new List<int>();
        string inventoryItems = PlayerPrefs.GetString("Inventory");
        string[] ids = inventoryItems.Split(new char[] { ' ' });
        for (int i = 0; i < ids.Length; i++)
        {
            int res;
            if (int.TryParse(ids[i], out res))
            {
                if (BoughtedItemID.Equals(int.Parse(ids[i])) == false)
                {
                    itemIDs.Add(int.Parse(ids[i]));
                }

            }

        }
        return itemIDs;
    }
   
}
