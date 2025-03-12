using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToClick : MonoBehaviour
{
    // https://www.youtube.com/watch?v=5KLV6QpSAdI
    // to add selectable players for crewmates later


    public float speed = 5f;
    public Rigidbody2D rb;
    private Vector3 target; // marker location (on-click)

    public bool hasKeycard = false;
    public bool isMoving = false;

    public Transform clickMarker;


    // get direction for animation / walk cycle
    public enum FacingDirection
    {
        left, right
    }

    public FacingDirection GetFacingDirection()
    {
        if (target.x < transform.position.x)
        {
            Debug.Log("marker left");
            return FacingDirection.left;
        }

        if (target.x > transform.position.x)
        {
            Debug.Log("marker right");
            return FacingDirection.right;
        }

        // default animation
        return FacingDirection.left;
    }



    // Start is called before the first frame update
    void Start()
    {
        target = transform.position;
        clickMarker.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) // LEFT CLICK
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;

            clickMarker.gameObject.SetActive(true);
            clickMarker.position = target;
            isMoving = true;

            TelemetryLogger.Log(this, "Click");
            TelemetryLogger.Log(this, "CurrentLocation", transform.position);
            //  UNCOMMENT THIS TO TEST IF ENUM RETURNS CORRECT VALUE
            //  GetFacingDirection();

        }

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (clickMarker.position == transform.position)
        {
            clickMarker.gameObject.SetActive(false);
            isMoving = false;
        }

    }

    public void GetKeycard()
    {
        hasKeycard = true;
    }

    // if player hits a wall, place marker at their position so movement stops
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            Debug.Log("hit wall!");
            clickMarker.gameObject.SetActive(false);
            target = transform.position;
            isMoving = false;
        }
    }

}
