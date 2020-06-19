using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Guns : MonoBehaviour
{
    public int Damage { get; protected set; }

    public float FireRate { get; protected set; }

    public virtual void UseGun()
    {

    }
}
