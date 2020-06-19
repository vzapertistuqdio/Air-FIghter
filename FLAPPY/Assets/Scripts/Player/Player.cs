using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static Player _player=new Player();

    private Inventory _inventroy = Inventory.GetInstance();

    private Guns currentGun;

    private Planes currentPlane;

    private Pilots currentPilot;

    private bool hasReincarnation;

    private int money;

    private Player() { }

    public static Player GetInstance()
    {
        return _player;
    }

    public void SetGun(Guns gun)
    {
        currentGun = gun;
    }

    public void SetPilot(Pilots pilot)
    {
        currentPilot = pilot;
    }

    public void SetPlane(Planes plane)
    {
        currentPlane=plane;
    }
    public Pilots GetPilot()
    {
       return currentPilot;
    }

    public Planes GetPlane()
    {
        return currentPlane;
    }


    public int GetMoney()
    {
        return money;
    }

    public void SetMoney(int amount)
    {
        PlayerPrefs.SetInt("Money",amount);
        money = PlayerPrefs.GetInt("Money");
    }

    public void PerformUseGun()
    {
        currentGun.UseGun();
    }
    public void Awake()
    {
    }

    private void  Start()
    {
        _player = GetComponent<Player>();
        money = PlayerPrefs.GetInt("Money");      
    }

    private void Update()
    {
        SetPilot(Shop.GetInstance().GetEquipPilot());
        SetPlane(Shop.GetInstance().GetEquipPlane());
        hasReincarnation = Shop.GetInstance().HasReincarnation();

    }
   

}
