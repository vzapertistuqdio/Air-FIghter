using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObstacleBehavior 
{
    void Move(Rigidbody2D rig,float speed);
}
