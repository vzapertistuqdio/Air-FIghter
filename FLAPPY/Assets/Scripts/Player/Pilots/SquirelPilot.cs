using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirelPilot : Pilots
{
    private static SquirelPilot _squirelPilot = new SquirelPilot();

    private SquirelPilot()
    {
        Luck = 34;
        Name = "SQUIREL";
        ID = 203;
        Cost = 85;
    }

    public static SquirelPilot GetInstance()
    {
        return _squirelPilot;
    }

    private void Start()
    {
        _squirelPilot = GetComponent<SquirelPilot>();
    }
}
