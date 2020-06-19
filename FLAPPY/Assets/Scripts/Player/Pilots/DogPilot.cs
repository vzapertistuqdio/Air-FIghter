using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogPilot : Pilots
{
    private static DogPilot _dogPilot = new DogPilot();

    private DogPilot()
    {
        Luck = 55;
        Name = "DOG";
        ID = 204;
        Cost = 850;
    }

    public static DogPilot GetInstance()
    {
        return _dogPilot;
    }

    private void Start()
    {
        _dogPilot = GetComponent<DogPilot>();
    }
}
