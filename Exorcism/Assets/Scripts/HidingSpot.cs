using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HidingSpot : MonoBehaviour
{
    //icon to toggle
    public GameObject icon;
    public GameObject player;
    public LayerMask layer;
    public float validHidingDistance;
    private bool isHiding = false;

    void Start()
    {
        //lazy assign for level designers
        Collider2D collider = Physics2D.OverlapCircle(transform.position, Mathf.Infinity, layer.value);
        player = collider.gameObject;
    }

    void Update()
    {
        
        //toggle the icon to hid when the player gets close
        if(Vector2.Distance(player.transform.position, transform.position) < validHidingDistance)
            //if we are close enough to hide
        {
            //activate the icon based on if the player is hiding or not
            icon.SetActive(!isHiding);
            if (Input.GetMouseButtonDown(1))//if the player right clicks and is within zone
            {
                isHiding = !isHiding;
                player.SetActive(!isHiding);
            }
        }

    }

s
}
