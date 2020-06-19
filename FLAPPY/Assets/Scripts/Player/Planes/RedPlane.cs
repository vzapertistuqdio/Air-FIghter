using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPlane : Planes
{
    private static RedPlane _redPlane=new RedPlane();

    private RedPlane()
    {
        Armor = 20;
        Name = "OCTOBER";
        ID = 101;
        Cost = 0;
        Damage = 1;
        ReloadTime = 0.1f;
    }

    public static RedPlane GetInstance()
    {
        return _redPlane;
    }

    private void Start()
    {     
        _redPlane = GetComponent<RedPlane>();
    }

    

}
