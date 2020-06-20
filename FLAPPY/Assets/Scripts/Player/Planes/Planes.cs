using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Planes : MonoBehaviour
{
    public int Armor { get; protected set; }
    public int Damage { get; protected set; }
    public string Name{ get; protected set; }
    public int ID { get; protected set; }
    public int Cost { get; protected set; }
    public float ReloadTime { get; protected set; }

    [SerializeField] public GameObject planeObject;
    [SerializeField] public GameObject bulletObject;
    private AudioSource bulletSound;


    public virtual void Spawn()
    {
        planeObject = Instantiate(planeObject) as GameObject;
        bulletSound = planeObject.GetComponent<AudioSource>();
        planeObject.transform.position = new Vector2(-5f, 0);
    }

    public virtual void Destroy()
    {
        Destroy(planeObject);
    }

    private bool canShoot = true;
    public void Shoot()
    {
        Bullet thisBullet;
        GameObject bullet;
        thisBullet = bulletObject.GetComponent<Bullet>();
        if (canShoot)
        {
            bulletSound.Play();
            bullet = Instantiate(bulletObject) as GameObject;
            bullet.transform.position = GameObject.Find("Gun").transform.position;
            canShoot = false;
            StartCoroutine(StartReload(ReloadTime));
        }
    }
    public virtual GameObject GetObject()
    {
        return planeObject;
    }
    public virtual GameObject GetBullet()
    {
        return bulletObject;
    }
    private IEnumerator StartReload(float time)
    {
        yield return new WaitForSeconds(time);
        canShoot = true;
    }
}
