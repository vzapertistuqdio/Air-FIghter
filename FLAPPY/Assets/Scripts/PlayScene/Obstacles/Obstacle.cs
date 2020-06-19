using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed;
    public float destroiableTime;
    public int damage;
    public int health;
    public IObstacleBehavior behavior;

 

    public void Move(Rigidbody2D rig,float speed)
    {
        behavior.Move(rig,speed);
    }
    public void SetBehavior(IObstacleBehavior beh)
    {
        behavior = beh;
    }
    public void Destroy(float requierTime)
    {
        StartCoroutine(DestroyAfterRequierTime(requierTime));
    }
    public IEnumerator DestroyAfterRequierTime(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(this.gameObject);
    }
  
}
