using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public enum PlaneMoveState { Up, Down,NotChanged,Right,Left }
public class Controller : MonoBehaviour {

    private bool isDown = false;
  

    public static PlaneMoveState stateVerticalVector;
    public static PlaneMoveState stateHorizontalVector;

    private Swipe swipe;

    private float sensetive = 0.015f;

    private Vector2 prevouseMousePosition;
	private void Start () {
        prevousPosition = transform.position;
        prevouseMousePosition = Vector2.zero;
        swipe = GameObject.FindGameObjectWithTag("Joystick").GetComponent<Swipe>();
    }	
	private void Update () {
        MouseController();
        ChangeMoveVector();
    }

   private void MouseController()
    {
        if (Input.mousePosition.x == prevouseMousePosition.x && Input.mousePosition.y == prevouseMousePosition.y)
        {
            swipe.swipeDelta = Vector2.zero;
        }
        if (swipe.isOnArea)
        {
            transform.position = new Vector2(Mathf.Clamp(transform.position.x + swipe.swipeDelta.x * 1.5f * sensetive, -10, 10), Mathf.Clamp(transform.position.y + swipe.swipeDelta.y * sensetive, -3.5f, 4.6f));
        }
        prevouseMousePosition = Input.mousePosition;
    }
    private Vector2 prevousPosition;
    private void ChangeMoveVector()
    {
        if(transform.position.y>prevousPosition.y)
        {
            stateVerticalVector = PlaneMoveState.Up;
        }
        else if(transform.position.y < prevousPosition.y)
        {
            stateVerticalVector = PlaneMoveState.Down;
        }
        else if(transform.position.y == prevousPosition.y)
        {
            stateVerticalVector = PlaneMoveState.NotChanged;
        }
        if(transform.position.x > prevousPosition.x)
        {
            stateHorizontalVector = PlaneMoveState.Right;
        }
        else if (transform.position.x < prevousPosition.x)
        {
            stateHorizontalVector = PlaneMoveState.Left;
        }
        else if (transform.position.x == prevousPosition.x)
        {
            stateHorizontalVector = PlaneMoveState.NotChanged;
        }
       prevousPosition = transform.position;
    }
}
