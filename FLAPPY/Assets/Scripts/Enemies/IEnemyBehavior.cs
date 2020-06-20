using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyBehavior 
{
    float FireRate { get; set; }
    void Shoot(GameObject bulletObj,Transform enemyTransfor);
    void Move(Rigidbody2D rgb);
}
