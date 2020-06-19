using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reincarnation : Buffs
{
    private static Reincarnation _reincarnation = new Reincarnation();

    private Reincarnation()
    {
        Name = "Reincarnation";
        ID = 301;
        Cost = 10000;
        
    }

    public static Reincarnation GetInstance()
    {
        return _reincarnation;
    }

    private void Start()
    {
        _reincarnation = GetComponent<Reincarnation>();
    }
}
