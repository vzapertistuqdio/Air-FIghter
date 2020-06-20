using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;

public class MouseOnJoystick : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public bool isOnCircle = false;
    public void OnPointerEnter(PointerEventData eventData)
    {
        isOnCircle = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isOnCircle = false;
    }

   
}
