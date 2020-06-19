using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class JoystickController : MonoBehaviour,IPointerDownHandler,IDragHandler,IPointerUpHandler
{

    private Image backgroundJoystick;
    private Image insideJoystick;

    private Vector2 inputVector;
    public void OnDrag(PointerEventData eventData)
    {

        Vector2 position;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(backgroundJoystick.rectTransform, eventData.position, eventData.pressEventCamera, out position))
        {
            position.x = (position.x / backgroundJoystick.rectTransform.sizeDelta.x);
            position.y = (position.y / backgroundJoystick.rectTransform.sizeDelta.y);
        }
        inputVector = new Vector2(position.x , position.y);
        inputVector = (inputVector.magnitude > 1) ? inputVector.normalized : inputVector;
        insideJoystick.rectTransform.localPosition = new Vector2(inputVector.x * (backgroundJoystick.rectTransform.sizeDelta.x/2 ), inputVector.y * (backgroundJoystick.rectTransform.sizeDelta.y/2 ));
       
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
        //insideJoystick.rectTransform.position = eventData.pressPosition;
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector2.zero;
        insideJoystick.rectTransform.localPosition = Vector2.zero;
    }

    public float GetVertical()
    {
        //return inputVector.y;
        int value = 0;
        if (inputVector.y > 0)
        {
            if (inputVector.y * 10 >= 1)
                value = 1;
        }
        else if (inputVector.y < 0)
        {
            if(inputVector.y>=-1)
                value = -1;
        }
        return value;
        
    }
    public float GetHorizontal()
    {
        //return inputVector.x;
        int value = 0;
        if (inputVector.x > 0)
        {
            if(inputVector.x * 10 >= 1)
            value = 1;
        }
        else if (inputVector.x < 0)
        {
            if (inputVector.x >= -1)
                value = -1;
        }
        return value;
    }

    private void Start()
    {
        backgroundJoystick = GetComponent<Image>();
        insideJoystick = GameObject.FindGameObjectWithTag("InsideJoystick").GetComponent<Image>();
    }
  
    private void Update()
    {
        
    }

 

    
}
