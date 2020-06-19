using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerPilot : Pilots
{
    private static TigerPilot _tigerPilot = new TigerPilot();

    private TigerPilot()
    {
        Luck = 24;
        Name = "TIGER";
        ID = 202;
        Cost = 45;
    }

    public static TigerPilot GetInstance()
    {
        return _tigerPilot;
    }

    private void Start()
    {
        _tigerPilot = GetComponent<TigerPilot>();
    }
}
