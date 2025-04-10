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
    public bool isHurt = false; //only enabled during damage cooldown

    public Transform clickMarker;

    public Inventory inv;
    public GameObject trap;

    public GameObject normalSprite;
    public GameObject flash1;
    public GameObject flash2;

    // TELEMETRY
    [System.Serializable]
    public struct MovementData
    {
        public Vector3 clickNode;
        public Vector3 playerPos;
        public bool hasCard;
    }


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

        if (inv.equiped[1] && inv.hasInInventory[1] && Input.GetMouseButtonDown(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;

            Debug.Log("tried placing trap");
            inv.PlaceTrap();
            Instantiate(trap, target, transform.rotation);
            return;

        }


        if (Input.GetMouseButtonDown(0)) // LEFT CLICK
        {
            if (Camera.main.ScreenToWorldPoint(Input.mousePosition).y < -3) // if player clicks OOB
            {
                return;
            }
            
            
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;


            clickMarker.gameObject.SetActive(true);
            clickMarker.position = target;
            isMoving = true;

            //  UNCOMMENT THIS TO TEST IF ENUM RETURNS CORRECT VALUE
            //  GetFacingDirection();


            var data = new MovementData()
            {
                clickNode = target,
                playerPos = transform.position,
                hasCard = hasKeycard
            };

            // only logs when player clicks
        //    TelemetryLogger.Log(this, "MoveToNode", data);


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

        if (collision.gameObject.name == "Ghost" && !isHurt)
        {
            StartCoroutine(DamageFlash(collision));
        }

        //Debug.Log(collision.gameObject);
    }

    private IEnumerator DamageFlash(Collision2D ghostCollider)
    {

        BoxCollider2D ghostCol = ghostCollider.gameObject.GetComponent<BoxCollider2D>();
        ghostCol.enabled = false;
        
        isHurt = true;
        
        normalSprite.SetActive(false);
        flash1.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        flash1.SetActive(false);
        flash2.SetActive(true);
        yield return new WaitForSeconds(1.25f);
        flash2.SetActive(false);
        normalSprite.SetActive(true);
        isHurt = false;

        ghostCol.enabled = true;
    }

    public void hide()
    {

    }

}
