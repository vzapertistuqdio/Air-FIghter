using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private GameObject database;

    [SerializeField] private WindowsSystem winSystem;

    public Animator scoreAnimator;
    public Animator healthAnimator;

    public Planes usablePlane;
    public Pilots usablePilot;

    private List<Planes> planes = new List<Planes>();
    private List<Pilots> pilots = new List<Pilots>();

    public bool isPlaneSpawned = false;
    public bool isPilotSpawned = false;

    private int health;

    private int score;
    private int destoyedEnemies;
    private int destoyedRockets;

    private void Start()
    {
        InitializePlanes();
        InitializePilots();
        usablePlane = SetUsablePlane(PlayerPrefs.GetInt("CurrentPilot"));
        SpawnPlane();
        SpawnPilot();
        health = usablePlane.Armor;
        Time.timeScale = 1;
        SetScore(PlayerPrefs.GetInt("Score"));
        //PlayerPrefs.DeleteKey("Score");
    }
    
    private void Update()
    {
        SpawnPlane();
       Debug.Log(PlayerPrefs.GetInt("Score"));
    }

    public void SpawnPlane()
    {
        while (usablePlane == null)
        {
            if(PlayerPrefs.GetInt("CurrentPlane")!=0)
             usablePlane = SetUsablePlane(PlayerPrefs.GetInt("CurrentPlane"));
            else usablePlane = SetUsablePlane(101);
        }
        if (usablePlane != null && isPlaneSpawned == false)
        {
            usablePlane.Spawn();
            isPlaneSpawned = true;
        }
    }
    public void SpawnPilot()
    {
        while (usablePilot == null)
        {
            if (PlayerPrefs.GetInt("CurrentPilot") != 0)
                usablePilot = SetUsablePilot(PlayerPrefs.GetInt("CurrentPilot"));
            else usablePilot = SetUsablePilot(201);
        }
        if (usablePilot != null && isPilotSpawned == false)
        {
            usablePilot.Spawn();
            isPilotSpawned = true;
        }
    }
    private void InitializePlanes()
    {
        planes.Add(RedPlane.GetInstance());
        planes.Add(PurpleHelicopter.GetInstance());
        planes.Add(Fighter.GetInstance());
        planes.Add(StartFighter.GetInstance());
        planes.Add(CosmoPlane.GetInstance());
    }
    private void InitializePilots()
    {
        pilots.Add(TigerPilot.GetInstance());
        pilots.Add(CatPilot.GetInstance());
        pilots.Add(SquirelPilot.GetInstance());
        pilots.Add(RacoonPilot.GetInstance());
        pilots.Add(DogPilot.GetInstance());

    }
    private Planes SetUsablePlane(int id)
    {
        Planes temp=null;
        foreach(Planes plane in planes)
        {
            if (plane.ID == id)
            {
                temp = plane;               
            }
        }
        return temp;
    }
    private Pilots SetUsablePilot(int id)
    {
        Pilots temp = null;
        foreach (Pilots pilot in pilots)
        {
            if (pilot.ID == id)
            {
                temp = pilot;
            }
        }
        return temp;

    }
    
   
    public void SetHealth(int value)
    {
        StartCoroutine(PlayUIHealthAnim());
        if (value <= 0)
        {
            health = value;
            OnDied();
        }
    }
    public int GetHealth()
    {
        return health;
    }
    public int GetScore()
    {
        return score;
    }
    public int GetDestroyedEnemies()
    {
        return destoyedEnemies;
    }
    public int GetDestroyedRocket()
    {
        return destoyedRockets;
    }

    public void IncreaseDestroyedEnemies()
    {
        destoyedEnemies++;
    }
    public void IncreaseDestroyedRockets()
    {
        destoyedRockets++;
    }
    public void SetScore(int value)
    {
        StartCoroutine(PlayUIScoreAnim());
        score = value;
    }
    public void ApplyDamage(int damage)
    {
       
        StartCoroutine(PlayUIHealthAnim());
        health = health - damage;      
    }
    public void Shoot()
    {
        usablePlane.Shoot();
    }

    public void OnDied()
    {
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money")+score);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetBool("isDead",true);     
        ParticleSystem[] playerParticles=GameObject.FindGameObjectWithTag("Player").GetComponentsInChildren<ParticleSystem>();
        ParticleSystem explosiveParticle = playerParticles[1];
        AudioSource explosiveSound= GameObject.FindGameObjectWithTag("ExplosiveSound").GetComponent<AudioSource>();
        bool hasReincarnation=Inventory.GetInstance().CheckItem(301);
        explosiveSound.Play();
        explosiveParticle.Play();
      
        StartCoroutine(OnDead());
        
    }

    private IEnumerator PlayUIScoreAnim()
    {
        scoreAnimator.SetBool("isScoreIncreasing", true);
        yield return new WaitForSeconds(0.15f);
        scoreAnimator.SetBool("isScoreIncreasing", false);
    }
    private IEnumerator PlayUIHealthAnim()
    {
        healthAnimator.SetBool("isHealthIncreasing", true);
        yield return new WaitForSeconds(0.15f);
        healthAnimator.SetBool("isHealthIncreasing", false);   
    }
    private IEnumerator OnDead()
    {
        yield return new WaitForSeconds(0.4f);
        usablePilot.Destroy();
        usablePlane.Destroy();
        winSystem.EnableDeathWindow();
        Time.timeScale = 0;
    }
  
}
