using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CosmoPlane : Planes
{
    private static CosmoPlane _cosmoPlane = new CosmoPlane();

    private CosmoPlane()
    {
        Armor = 250;
        Name = "COSMO";
        ID = 105;
        Cost = 15000;
        Damage = 20;
        ReloadTime = 2f;
    }

    public static CosmoPlane GetInstance()
    {
        return _cosmoPlane;
    }

    private void Start()
    {
        _cosmoPlane = GetComponent<CosmoPlane>();
    }
}
