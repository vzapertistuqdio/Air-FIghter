using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseButtonsEffects : MonoBehaviour
{
    private Animator anim;

    private AudioSource audioSrc;

    private float TIME_ANIM_STOP = 0.2f;

    void Start()
    {
        anim = GetComponent<Animator>();

        audioSrc = GetComponent<AudioSource>();
    }
    
    public void OnClick()
    {
        anim.SetBool("IsClicked", true);
        audioSrc.Play();
        StartCoroutine(WaitEndAnimation());
    }

    public void OnToggleClick()
    {
        if (audioSrc != null)
        {
            audioSrc.Play();
        }
    }

    private IEnumerator WaitEndAnimation()
    {
        yield return new WaitForSeconds(TIME_ANIM_STOP);
        anim.SetBool("IsClicked", false);

    }
}
