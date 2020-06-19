using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RochetBehavior : MonoBehaviour,IObstacleBehavior
{
   public  void Move(Rigidbody2D rig,float speed)
    {
        rig.velocity = new Vector2(-2f*speed,0f);
    }
}
