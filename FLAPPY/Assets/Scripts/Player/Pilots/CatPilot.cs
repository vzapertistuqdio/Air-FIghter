using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatPilot : Pilots
{
    private static CatPilot _catPilot = new CatPilot();

    private CatPilot()
    {
        Luck = 5;
        Name = "CAT";
        ID = 201;
        Cost = 0;
    }

    public static CatPilot GetInstance()
    {
        return _catPilot;
    }

    private void Start()
    {
        _catPilot = GetComponent<CatPilot>();
    }
}
