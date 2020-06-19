using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleHelicopter : Planes
{

    private static PurpleHelicopter _purpleHelicopter=new PurpleHelicopter();

    private PurpleHelicopter()
    {
        Armor = 35;
        Name = "RAPTOR";
        ID = 102;
        Cost = 350;
        Damage = 4;
        ReloadTime = 0.2f;
    }

    public static PurpleHelicopter GetInstance()
    {
        return _purpleHelicopter;
    }

    private void Start()
    {
        _purpleHelicopter = GetComponent<PurpleHelicopter>();
    }

}
