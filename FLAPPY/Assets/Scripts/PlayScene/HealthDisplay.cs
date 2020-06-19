using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    private int health;
    [SerializeField] private GameObject healthText;
  
    private void Update()
    {
        Display();
    }

    private void Display()
    {
        health = GetComponent<PlayerView>().GetHealth();
        healthText.GetComponent<Text>().text = ""+health;
    }
}
