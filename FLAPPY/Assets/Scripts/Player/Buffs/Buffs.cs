using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buffs : MonoBehaviour
{
    public string Name { get; protected set; }
    public int ID { get; protected set; }
    public int Cost { get; protected set; }

    [SerializeField] public GameObject buffObject;

    public virtual GameObject GetObject()
    {
        return buffObject;
    }
}
