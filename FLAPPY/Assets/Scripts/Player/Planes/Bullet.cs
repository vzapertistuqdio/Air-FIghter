using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;

    public float speed;

   
    private void Start()
    {
        Destroy(2f);
    }
  
    private void Update()
    {
        transform.Translate(speed*Time.deltaTime,0,0);
    }
    public void Destroy(float requierTime)
    {
        StartCoroutine(DestroyAfterRequierTime(requierTime));
    }
    private IEnumerator DestroyAfterRequierTime(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(this.gameObject);
    }
}
