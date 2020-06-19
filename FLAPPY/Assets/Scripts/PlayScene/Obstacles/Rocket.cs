using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : Obstacle
{
    private Rigidbody2D rocketRigibody;
    
    public Rocket() 
    {
        speed = 3f;
        damage = 1;
        destroiableTime = 2f;
        health = 1;
        behavior = new RochetBehavior();
    }

    void Start()
    {
        rocketRigibody = GetComponent<Rigidbody2D>();
    }

   
    void Update()
    {
        Move(rocketRigibody,speed);
        Destroy(destroiableTime);
    }
    
}
