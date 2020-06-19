using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : Planes
{

    private static Fighter _fighter = new Fighter();

    private Fighter()
    {
        Armor = 55;
        Name = "FIGHTER";
        ID = 103;
        Cost = 5000;
        Damage = 6;
        ReloadTime = 0.5f;
    }

    public static Fighter GetInstance()
    {
        return _fighter;
    }

    private void Start()
    {
        _fighter = GetComponent<Fighter>();
    }
}
