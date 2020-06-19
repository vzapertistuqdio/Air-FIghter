using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleEnemyBehavior : MonoBehaviour,IEnemyBehavior
{
    public float FireRate { get => fireRate; set => fireRate = value; }

    private float fireRate = 1f;
    private Vector2 moveVector;
   
    public void Move(Rigidbody2D rgb)
    {
        rgb.transform.position = new Vector2(Mathf.Clamp(rgb.transform.position.x, -12, 10), Mathf.Clamp(rgb.transform.position.y,-3.6f, 4.6f));

        Vector2 moveVector = Vector2.left ;
        if (rgb.transform.position.x < 0.85f)
            moveVector = Vector2.left;
        else
            moveVector = new Vector2(-1, Random.Range(-1,2)*1);
        rgb.velocity = moveVector;
        
    }

    
    public void Shoot(GameObject bulletObj, Transform enemyTransform)
    {
        GameObject bullet;
        bullet = Instantiate(bulletObj) as GameObject;
        bullet.transform.position = enemyTransform.position;
    }

 

   
   
}
