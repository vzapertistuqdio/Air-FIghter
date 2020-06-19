using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Window : MonoBehaviour
{
    [SerializeField] private GameObject windowObj;
     public virtual void On()
    {
        windowObj.SetActive(true);
    }
    public virtual void Off()
    {
        windowObj.SetActive(false);
    }
}
