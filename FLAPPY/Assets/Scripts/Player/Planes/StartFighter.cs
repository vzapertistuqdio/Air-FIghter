using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFighter : Planes
{
    private static StartFighter _starFighter = new StartFighter();

    private StartFighter()
    {
        Armor = 70;
        Name = "STAR EXPLORER";
        ID = 104;
        Cost = 500;
        Damage = 8;
        ReloadTime = 0.1f;
    }

    public static StartFighter GetInstance()
    {
        return _starFighter;
    }

    private void Start()
    {
        _starFighter = GetComponent<StartFighter>();
    }
}
