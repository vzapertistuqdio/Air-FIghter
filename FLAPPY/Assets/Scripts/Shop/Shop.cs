using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    private List<Planes> PlanesCollection = new List<Planes>();
    private List<Pilots> PilotsCollection = new List<Pilots>();
    private List<Buffs> BuffsCollection = new List<Buffs>();


    [SerializeField] private Text textForParametres;
    [SerializeField] private Text moneyText;

    private IShopMode shopMode;
    
    private Shop() { }

    private static Shop _shop = new Shop();

    public static Shop GetInstance()
    {
        return _shop;
    } 

    public void Add(Planes plane)
    {
        PlanesCollection.Add(plane);
    }
    public void Add(Pilots pilot)
    {
        PilotsCollection.Add(pilot);
    }
    public void Add(Buffs buff)
    {
        BuffsCollection.Add(buff);
    }

    public Planes GetPlane(int id)
    {
        if (id < 0)
        {
            throw new MissingReferenceException();
        }
        else
            return PlanesCollection[id];
    }
    public Pilots GetPilot(int id)
    {
        if (id < 0)
        {
            throw new MissingReferenceException();
        }
        else
            return PilotsCollection[id];
    }
    public Buffs GetBuff(int id)
    {
        if (id < 0)
        {
            throw new MissingReferenceException();
        }
        else
            return BuffsCollection[id];
    }

    public int GetSizeCollection(string NameOfCollection)  
    {
        switch (NameOfCollection)
        {
            case "PlanesCollection": return PlanesCollection.Count;
            case "PilotsCollection": return PilotsCollection.Count;
            case "BuffsCollection": return BuffsCollection.Count;
            default:throw new MissingReferenceException();
        }
    }

    private int currentShowId =0;

    public void SetCurrentShowId(int id)
    {
        currentShowId = id;
    }
    public int GetCurrentShowId()
    {
        return currentShowId;
    }

    public int GetShopModeSize()
    {
        return shopMode.GetArraySize();
    } 

    public void SetShopMode(IShopMode mode)
    {
        shopMode = mode;    
    } 

    public IShopMode GetShopMode()
    {
        return shopMode;
    }

    public int GetShowItemCost()
    {
        int cost = shopMode.GetShowItemCost(GetCurrentShowId());
        return cost;
    }

    public int GetShowItemID(int id)  
    {
       return shopMode.GetShowItem(id);
    }
  
    public void PreferClick()
    {
        OnEquipClick(GetCurrentShowId());
    }
    public Planes GetEquipPlane()
    {
        Planes temp=null;
        foreach(Planes plane in PlanesCollection)
        {
            if(plane.ID==PlayerPrefs.GetInt("CurrentPlane"))
            {
                temp = plane;
               
            }
        }
        return temp;
    }
    public Pilots GetEquipPilot () 
    {
       Pilots temp = null;
        foreach (Pilots pilot in PilotsCollection)
        {
            if (pilot.ID == PlayerPrefs.GetInt("CurrentPilot"))
            {
                temp =pilot;
               
            }
        }
        return temp;
    }
    public bool HasReincarnation()
    {
        foreach (Buffs buff in BuffsCollection)
        {
            if (buff.ID == PlayerPrefs.GetInt("Buffs"))
            {
                return true;
                
            }
        }
        return false;
    }
    public void DestroyDisplayItem()
    {
        shopMode.DestroyDisplayedItem();
    }


    private void OnEquipClick(int id)
    {       
        shopMode.OnEquipClick(id);
    }
    private void Start()
    {
        _shop = GetComponent<Shop>();
        InitializeShop();
        shopMode = new PlaneMode();
    }

    private void Update()
    {
        PreferDisplay(currentShowId);
        moneyText.text = Player.GetInstance().GetMoney().ToString();
    }


    private void PreferDisplay(int id)
    {
        shopMode.Display(id);
        DisplayParameters(id,textForParametres);
    }

    private void InitializeShop()
    {
       PlanesCollection.Add(RedPlane.GetInstance());
       PlanesCollection.Add(PurpleHelicopter.GetInstance());
        PlanesCollection.Add(CosmoPlane.GetInstance());
        PlanesCollection.Add(Fighter.GetInstance());
        PlanesCollection.Add(StartFighter.GetInstance());

        PilotsCollection.Add(TigerPilot.GetInstance());
        PilotsCollection.Add(CatPilot.GetInstance());
        PilotsCollection.Add(SquirelPilot.GetInstance());
        PilotsCollection.Add(RacoonPilot.GetInstance());
        PilotsCollection.Add(DogPilot.GetInstance());

        BuffsCollection.Add(Reincarnation.GetInstance());
    }

    private void DisplayParameters(int id,Text text)
    {
        shopMode.DisplayParameters(id,text);
    }


  


}
