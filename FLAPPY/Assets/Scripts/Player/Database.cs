using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour
{
    private static Database _database = new Database();
    private Database() { }

    public GameObject[] planeObjects;

    public Sprite[] planeSprites;

    void Start()
    {     
        _database = GetComponent<Database>();
    }


    public static Database GetInstance()
    {
        return _database;
    }
    
  
}
