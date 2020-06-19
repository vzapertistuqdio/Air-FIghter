using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButtons : MonoBehaviour
{
    private Player player;
    private Shop shop;
    private Inventory inventory;

    public GameObject buyButton;
    public GameObject equipButton;

    public void OnNextButtonClick()  //При нажатии отображается следующий предмет
    {
        if(GetCurrentShowId()== GetShopModeCollectionSize()) //Если достигнут конец коллекции,то отображение предметов начинается с начала коллекции
        {
            SetCurrentShhowId(0);
        }
        else
        {
            int id = GetCurrentShowId() + 1;
            SetCurrentShhowId(id);
        }
        Shop.GetInstance().DestroyDisplayItem();
    }
    public void OnPrevousButtonClick()
    {
        if (GetCurrentShowId() == 0)
        {
           int maxId= GetShopModeCollectionSize();
            SetCurrentShhowId(maxId);
        }
        else
        {
            int id = GetCurrentShowId() - 1;
            SetCurrentShhowId(id);
        }
        Shop.GetInstance().DestroyDisplayItem();
    }

    public void SetShopMode(int numberOfShopMode)
    {
        Shop.GetInstance().DestroyDisplayItem();
        switch (numberOfShopMode)
        {
            case 1:Shop.GetInstance().SetShopMode(new PlaneMode());
                break;
            case 2:Shop.GetInstance().SetShopMode(new PilotMode());
                break;
            case 3:Shop.GetInstance().SetShopMode(new OtherMode());
                break;
            default: throw new MissingReferenceException();
        }
       
    }

    public void OnBuyButtonCliCk()
    {
        if (player.GetMoney() >= shop.GetShowItemCost())
        {
          
                inventory.Add(shop.GetShowItemID(GetCurrentShowId()));

                inventory.Save();

                int itemCost = shop.GetShowItemCost();

                player.SetMoney(player.GetMoney() - itemCost);
            

        }
    }

    private void Start()
    {
        player = Player.GetInstance();
        shop = Shop.GetInstance();
        inventory = Inventory.GetInstance();
    }
    private void Update()
    {
        DisplayBuyButton();
        DisplayEquipButton();
       
    }

    private void DisplayBuyButton()
    {
        if( inventory.CheckItem(shop.GetShowItemID(GetCurrentShowId())) )
        {
            StartCoroutine(DisplayButton(buyButton,false));         
        }
        else buyButton.SetActive(true);
    } 

    private void DisplayEquipButton()
    {   
        if (inventory.CheckItem(shop.GetShowItemID(GetCurrentShowId())))
        {
            StartCoroutine(DisplayButton(equipButton, true));
            if(ComprareItemID(shop.GetShowItemID(GetCurrentShowId())))
            {
                StartCoroutine(DisplayButton(equipButton, false));
            }
        }
        else if(inventory.CheckItem(shop.GetShowItemID(GetCurrentShowId()))==false)
        {
            StartCoroutine(DisplayButton(equipButton,false));
        }

        if(Shop.GetInstance().GetShopMode().GetType()==typeof(OtherMode))
        {
            StartCoroutine(DisplayButton(equipButton, false));
        }
    
    }

    private void SetCurrentShhowId(int id)   
    {
        Shop.GetInstance().SetCurrentShowId(id);
    }

    private int GetCurrentShowId()
    {
       return Shop.GetInstance().GetCurrentShowId();
    }

    private int GetShopModeCollectionSize()
    {
        return Shop.GetInstance().GetShopModeSize() - 1;
    }

    private IEnumerator DisplayButton(GameObject btn,bool value) //Что анимация и звук проигрываться успевал
    {
        yield return new WaitForSeconds(0.2f);
        btn.SetActive(value);
    }

    private bool ComprareItemID(int id)
    {
        List<int> idItemID = new List<int>();

        if(player.GetPilot()!=null)
        {
            idItemID.Add(player.GetPilot().ID);
        }
        if (player.GetPlane() != null)
        {
            idItemID.Add(player.GetPlane().ID);
        }
        foreach (int ids in idItemID)
        {
            if (ids == id)
                return true;
           
        }
        return false;
       
    }

}
