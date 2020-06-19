using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pilots :MonoBehaviour
{

    public int Luck { get; protected set; }
    public string Name { get; protected set; }
    public int ID { get; protected set; }
    public int Cost { get; protected set; }

    [SerializeField] public GameObject pilotObject;

 
    public enum BodyParts { Head,Scarf,Body};


    public virtual void Spawn()
    {
        GameObject sitPos = GameObject.FindGameObjectWithTag("PilotPlace");
        pilotObject = Instantiate(pilotObject) as GameObject;
        pilotObject.transform.parent = sitPos.transform;
        pilotObject.transform.position = sitPos.transform.position;
    }
    public virtual void Destroy()
    {
        Destroy(pilotObject);
    }



    public virtual GameObject GetObject()
    {
        return pilotObject;
    }

    
}
