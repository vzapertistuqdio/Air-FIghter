using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet
{
    private Vector2 moveVector;
    private PlayerView player;
    private ParticleSystem particleSyst;
    private void Start()
    {
        player = GameObject.FindObjectOfType<PlayerView>().GetComponent<PlayerView>();
        Destroy(2f);
        CalculateDirectionOnPlayer();
        particleSyst = GetComponentInChildren<ParticleSystem>();
    }

   
    private void Update()
    {
        transform.Translate(speed*Time.deltaTime,0,0);
    }
    private void CalculateDirectionOnPlayer()
    {     
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            float deltaX = transform.position.x - player.transform.position.x;
            float deltaY = transform.position.y - player.transform.position.y;
            float angle = Mathf.Atan(deltaY / deltaX) * Mathf.Rad2Deg;
            if (player.transform.position.x - transform.position.x < 0)
            {
                angle = 180 + angle;

            }
            else Destroy(0);
            int offset = Random.Range(-5,6);
            transform.rotation = Quaternion.Euler(0, 0, angle+offset);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            particleSyst.Play();
            
            if (player.GetHealth() > 1)
                player.ApplyDamage(damage);
            else player.OnDied();
            Destroy(0.1f);
        }
    }
}
