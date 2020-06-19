using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketTrigger : MonoBehaviour,IDamagable
{
    private PlayerView player;
    private bool isFirstenter = true;
    private ParticleSystem particleSyst;
    private Rocket rocket;
    private int health;

    public int scoreCost;

    private GameObject soundObject;
    private AudioSource explosiveSound;
    private void Start()
    {
        player = GameObject.FindObjectOfType<PlayerView>().GetComponent<PlayerView>();
        particleSyst = GetComponentInChildren<ParticleSystem>();
        rocket = GetComponent<Rocket>();
        health = rocket.health;
        soundObject = GameObject.FindGameObjectWithTag("ExplosiveSound");
        explosiveSound = soundObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       Enemy enemy=collision.GetComponent<Enemy>();
        if(enemy!=null)
        {
            Physics2D.IgnoreCollision(collision.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        if (collision.tag == "Player")
        {
            if (isFirstenter)
            {
                explosiveSound.Play();
                int damage = GetComponent<Rocket>().damage;
                if (player.GetHealth() > 1)
                    player.ApplyDamage(damage);
                else player.OnDied();
                isFirstenter = false;
            }
            particleSyst.Play();
            StartCoroutine(Destroy());
        }
        Bullet bullet = collision.GetComponent<Bullet>();
        if(bullet!=null && bullet.GetType()!=typeof(EnemyBullet))
        {
            ApplyDamage(bullet.damage);
            player.SetScore(player.GetScore() + scoreCost);
            player.IncreaseDestroyedRockets();
            Destroy(collision);
        }
    }
    
    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(this.gameObject);
    }

   public void ApplyDamage(int damage)
    {
        if (health - damage <= 0)
        {
            particleSyst.Play();
            explosiveSound.Play();
            StartCoroutine(Destroy());
        }
        else health = health - damage;
    }
}
