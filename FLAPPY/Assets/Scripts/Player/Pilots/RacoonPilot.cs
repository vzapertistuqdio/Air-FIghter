using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacoonPilot : Pilots
{
    private static RacoonPilot _racoonPilot = new RacoonPilot();

    private RacoonPilot()
    {
        Luck = 78;
        Name = "RACOON";
        ID = 205;
        Cost = 899;
    }

    public static RacoonPilot GetInstance()
    {
        return _racoonPilot;
    }

    private void Start()
    {
        _racoonPilot = GetComponent<RacoonPilot>();
    }
}
