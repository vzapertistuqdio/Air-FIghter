using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPlaneANIM : MonoBehaviour
{
   
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {

        if (Controller.stateVerticalVector == PlaneMoveState.Down)
        {
            anim.SetBool("StateDown", true);
            anim.SetBool("StateUp", false);
            anim.SetBool("StateNo", false);
        }
        if (Controller.stateVerticalVector == PlaneMoveState.Up)
        {
            anim.SetBool("StateDown", false);
            anim.SetBool("StateUp", true);
            anim.SetBool("StateNo", false);

        }
        if (Controller.stateVerticalVector == PlaneMoveState.NotChanged)
        {
            anim.SetBool("StateDown", false);
            anim.SetBool("StateUp", false);
            anim.SetBool("StateNo", true);        
        }
        if(Controller.stateHorizontalVector == PlaneMoveState.Right)
        {
              anim.SetBool("StateNo", false);
            anim.SetBool("StateRight", true);
            anim.SetBool("StateLeft", false);
        }
        if (Controller.stateHorizontalVector == PlaneMoveState.Left)
        {
            anim.SetBool("StateNo", false);
            anim.SetBool("StateRight", false);
            anim.SetBool("StateLeft", true);
        }
        if (Controller.stateHorizontalVector == PlaneMoveState.NotChanged)
        {
            anim.SetBool("StateNo", true);
            anim.SetBool("StateRight", false);
            anim.SetBool("StateLeft", false);
        }

    }
}
