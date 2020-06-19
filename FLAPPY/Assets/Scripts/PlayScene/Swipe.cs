using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Swipe : MonoBehaviour,IDragHandler, IPointerEnterHandler, IPointerExitHandler,IPointerDownHandler,IPointerUpHandler
{
   public Vector2 swipeDelta;
    public bool isOnArea= false;

    [SerializeField] private Text tapToControllText;
    private Image joystickBackroundImage;

    [SerializeField] public Image swipeJoystick;

    public void OnDrag(PointerEventData eventData)
    {
         swipeDelta = eventData.delta;
        if(Input.mousePosition.x<700)
         swipeJoystick.transform.position = Input.mousePosition;
       
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        isOnArea = true;
        tapToControllText.enabled = false;
        joystickBackroundImage.color = new Color(joystickBackroundImage.color.r, joystickBackroundImage.color.g, joystickBackroundImage.color.b,0);
  
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isOnArea = false;
        tapToControllText.enabled = true;
        joystickBackroundImage.color = new Color(joystickBackroundImage.color.r, joystickBackroundImage.color.g, joystickBackroundImage.color.b, 0.15f);
        swipeJoystick.enabled = false;
    }
    private void Start()
    {
        joystickBackroundImage = GetComponent<Image>();
        swipeJoystick.enabled = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        swipeJoystick.enabled = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        swipeJoystick.enabled = false;
    }
}
