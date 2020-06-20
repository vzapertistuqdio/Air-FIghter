using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initislize : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Inventory.GetInstance().Load();
    }

   
}
