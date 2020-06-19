using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour,IDamagable
{
    public int health;

    public int scoreCost;

    public int fireRate;

    private ParticleSystem[] particleSystems;

    private IEnemyBehavior enemyBehavior;

    private Rigidbody2D rgb;

    private GameObject soundObject;
    private AudioSource explosiveSound;

    private SpriteRenderer renderer;

    private GameObject controllerObject;
    private PlayerView player;

    [SerializeField] private GameObject bulletObj;
    public void ApplyDamage(int damage)
    {
        StartCoroutine(HitColor());
        health = health - damage;
        if(health<=0)
        {
            OnEnemyDeath();
        }
    }

    
    private void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
        SetBehavior(new CircleEnemyBehavior());
        particleSystems = GetComponentsInChildren<ParticleSystem>();
        soundObject = GameObject.FindGameObjectWithTag("ExplosiveSound");
        explosiveSound = soundObject.GetComponent<AudioSource>();
        renderer = GetComponent<SpriteRenderer>();

        controllerObject = GameObject.FindGameObjectWithTag("Controller");
        player = controllerObject.GetComponent<PlayerView>();


        InvokeRepeating("Shoot",1,fireRate);
        InvokeRepeating("PreferMove", 1, 1);
    }

    private void Update()
    {
    }
    private void OnEnemyDeath()
    {
        particleSystems[0].Play();
        explosiveSound.Play();
        player.SetScore(player.GetScore()+scoreCost);
        player.IncreaseDestroyedEnemies();
        StartCoroutine(Destroy());
    }
    private void Shoot()
    {
        enemyBehavior.Shoot(bulletObj,transform);
    }
    private void PreferMove()
    {
        enemyBehavior.Move(rgb);
    }

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bullet bullet = collision.GetComponent<Bullet>();
        if(bullet!=null && bullet.GetType()!=typeof(EnemyBullet))
        {      
            Destroy(collision.gameObject);
            ApplyDamage(bullet.damage);        
        }
        if(collision.tag=="Player")
        {
            particleSystems[0].Play();
            explosiveSound.Play();
            player.OnDied();
        }
    }
    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(this.gameObject);
    }
    private IEnumerator HitColor()
    {
        Color prevouisColor = renderer.color;
        if (renderer.color == Color.red)
        {
            prevouisColor = Color.white;
        }     
        renderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        renderer.color = prevouisColor;  
    }
    public void SetBehavior(IEnemyBehavior behavior)
    {
        enemyBehavior = behavior;
    }
    public void SetFireRate(float value)
    {
        enemyBehavior.FireRate = value;
    }
}
