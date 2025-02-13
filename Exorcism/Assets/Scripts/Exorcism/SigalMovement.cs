using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class SigalMovement : MonoBehaviour
{
    public GameObject exorcismManager;
    public int movementType;
    public float speed;
    public float turnSpeed;
    public float acceleration;

    public float length, width;



    private Vector2 goal;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        //create the goal location based on the type of movement
        float x, y;
        switch (movementType) {
            
            case 1://bounceBack to the same side that it came back on
                //go to the same side that it had enter on
                x = transform.position.x;
                
                //choose a random point on the oposite side that it came from
                if (transform.position.y < exorcismManager.transform.position.y)//if the sigil came from the bottom send it to the top
                {
                    y = Random.Range(exorcismManager.transform.position.y, exorcismManager.transform.position.y + width / 2);
                }
                else//if top then bottom
                {
                    y = Random.Range(exorcismManager.transform.position.y - width / 2, exorcismManager.transform.position.y);
                }

                goal = new Vector2(x, y);
                goalTransform.position = goal;
                break;

            default://goes Across the scene either movement 0 or 2
                if (transform.position.x < exorcismManager.transform.position.x)//sigil is going from left to right
                {
                    x = exorcismManager.transform.position.x + length / 2;
                }
                else//sigil is going from right to left
                {
                    x = exorcismManager.transform.position.x - length / 2;
                }
                y = Random.Range(exorcismManager.transform.position.y - (width / 2), exorcismManager.transform.position.y + (width / 2));
                goal = new Vector2(x, y);
                goalTransform.position = goal;
                break;
        }

        Debug.Log(goal);
        rb = gameObject.GetComponent<Rigidbody2D>();
        Destroy(gameObject, 10);
    }

    private float timer = 0;
    public Transform goalTransform;
    public float amptitude = 1, period = 1;
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        switch (movementType)
        {


            case 2://sin wave
                Vector2 direction = exorcismManager.transform.position - transform.position;
                
                float angle = Mathf.Atan2(direction.y, direction.x );
                Debug.Log(angle);
                Vector2 sinwave = amptitude * Mathf.Sin((360/period)*timer * Mathf.Deg2Rad) * (new Vector2(Mathf.Abs(Mathf.Sin(angle)), Mathf.Abs(Mathf.Cos(angle))));
                Debug.Log(sinwave);
                transform.position += (Vector3)sinwave + (transform.right*Time.deltaTime);
                break;
            default: //straight/simi-linear movement
                 turn(goal - (Vector2)transform.position);
                rb.velocity = transform.right * speed;
                break;
        }
    }


    public float turnDebuffer = 1f;
    private void turn(Vector3 direction)
    {

        float currentAngle = (Mathf.Atan2(transform.right.y, transform.right.x) * Mathf.Rad2Deg);
        float targetAngle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
        //Debug.Log(currentAngle + ", " + targetAngle);
        if (currentAngle < 0)
            currentAngle += 360;
        if (targetAngle < 0)
            targetAngle += 360;
        Debug.Log(currentAngle + ", " + targetAngle);
        //Debug.Log(Mathf.FloorToInt(180 + currentAngle) % 360);
        //if we are not in our buffer range then we move
        if (Mathf.Abs(currentAngle - targetAngle) > turnDebuffer)
        {

            if (targetAngle < currentAngle)
            {
                if (Mathf.Abs(currentAngle - targetAngle) < 180)
                {
                    transform.Rotate(new Vector3(0, 0, -1 * turnSpeed * Time.deltaTime));
                }
                else
                {
                    transform.Rotate(new Vector3(0, 0, turnSpeed * Time.deltaTime));//turn counterclockwise
                }
            }
            else
            {
                if (Mathf.Abs(currentAngle - targetAngle) < 180)
                {
                    transform.Rotate(new Vector3(0, 0, turnSpeed * Time.deltaTime));//turn counterclockwise

                }
                else
                {
                    transform.Rotate(new Vector3(0, 0, -1 * turnSpeed * Time.deltaTime));
                }

            }


        }

    }//end turn function

    //when the player clicks on the mouse
    private void OnMouseDown()
    {
        //TODO:play animation

        //update the progression

        //destroy object
        Destroy(gameObject);
    }

}
