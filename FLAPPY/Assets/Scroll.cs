using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    private Renderer rend;
    
    public float speed = 0.1f;
    void Start()
    {
         rend=GetComponent<Renderer>();
      
    }

    
    void Update()
    {
       
        Vector2 offset = new Vector2(Time.time * speed, 0);
        rend.material.mainTextureOffset = offset;
    }
   
}
