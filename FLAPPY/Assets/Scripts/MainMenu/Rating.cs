using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rating : MonoBehaviour
{
    private bool isOpened = false;

    [SerializeField] private GameObject ratingWindow;

    private void Start()
    {
        ratingWindow.SetActive(false);
    }
    public void OnOpenRating()
    {
        if (isOpened == false)
        {
            ratingWindow.SetActive(true);
            isOpened = true;
        }
        else
        {
            ratingWindow.SetActive(false);
            isOpened = false;
        }
    }
}
