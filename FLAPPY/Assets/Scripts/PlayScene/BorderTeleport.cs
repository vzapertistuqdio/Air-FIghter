using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderTeleport : MonoBehaviour
{
    [SerializeField] private GameObject pointTo;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.position = new Vector2(collision.transform.position.x,pointTo.transform.position.y);
    }
}
