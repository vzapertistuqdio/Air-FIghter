using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    private float score;
    [SerializeField] private GameObject scoreText;

    private void Update()
    {
        Display();
    }
    private void Display()
    {
        score = GetComponent<PlayerView>().GetScore();
        scoreText.GetComponent<Text>().text = "" + (int)score;
    }
}
