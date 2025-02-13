using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Xml.Schema;
using Unity.VisualScripting;
using UnityEngine;

public class ExorcismManager : MonoBehaviour
{

    public static float progression = 0;
    public float decreasingRate = 1;
    public float spawnRate = 1;
    public float[] percentageRate;
    public List<GameObject> sigilPrefabs;// = new List<GameObject>();
    private float timer;
    public GameObject pocession;  
    public Transform sigilTransforms;

    // Start is called before the first frame update
    void Start()
    {


        timer = 0;
        //double check the chances for each sigal
       float totalChance = 0;
       foreach(float chance in percentageRate)
       {
            totalChance += chance;
       }
       
       if(totalChance > 1)
       {
            Debug.LogError("Total percentage does not equal to 100%");
       }

       //set the exorcism 
       resetExorcism();
    }

    // Update is called once per frame
    void Update()
    {
        if (progression >= 100)
        {
            Destroy(sigilTransforms.gameObject);
            setPossessedSprite(false);
            return;
        }
        //spawn a new sigil every so often
        timer += Time.deltaTime;
        //Debug.Log(timer);
        if(timer >= spawnRate && progression < 100)
        {
            timer = 0;
            spawnSigil();
        }


        //successful able to exorcism them
        

        progression -= decreasingRate * Time.deltaTime;
        Debug.Log("Exorcism Progression: "+progression);
    }


    public float width, length;
    //TO DO
    public void spawnSigil()
    {
        //choose a sigil to spawn
        float choice = Random.Range(0, 1f);
        int index = 0;
        float total = 0;
        for (index = 0; index < percentageRate.Length; index++)
        { total += percentageRate[index];
            if(choice <= total)
            {
                break;//we exit the loop if our choice falls into the percentage range
            }
        }

        //chose spawn location and direction
        float x;
        if (Random.Range(0, 1f) >= 0.5f)
        {
            x = transform.position.x - (length / 2);
        }
        else
        {
            x = transform.position.x + (length / 2);
        }
        Vector2 position = new Vector2(x, Random.Range(transform.position.y - (width/2), transform.position.y + (width / 2)));
        

        //create the object
        GameObject sigil = Instantiate(sigilPrefabs[index], position, transform.rotation, sigilTransforms);
        SigalMovement sigilMove = sigil.GetComponent<SigalMovement>();
        sigilMove.exorcismManager = gameObject;
        sigilMove.length = length;
        sigilMove.width = width;

    }//end spawn sigil


    //DONE - to be tested
    public void resetExorcism()
    {
        //reset the time
        timer = 0;

        //restart the progression
        progression = 0;

        //make the crewmate possessed
        setPossessedSprite(true);


        if (sigilTransforms == null)
        {
            GameObject sigils = new GameObject("sigilTransforms");
            sigils.transform.position = transform.position;
            sigilTransforms = sigils.transform;
        }

    }//reset exorcism

    //DONE-- TO BE TESTED
    public void setPossessedSprite(bool isPossessed)
    {

        //----------------------------------------------------find the body of the crewmate
        GameObject body = null;
        //search for possession in the child
        for (int i = 0; i < pocession.transform.childCount; i++)
        {
            body = pocession.transform.GetChild(i).gameObject;
            if (body.name == "body")
            {
                break;//if we found the pocessed body then we break from the loop
            }

        }

        //------------------------------------------------find the related sprites and disable them
        //search the body assets
        if (body != null)
            for (int i = 0; i < body.transform.childCount; i++)
            {

                GameObject part = body.transform.GetChild(i).gameObject;


                if (part.name == "possessed")//if this is the body is the possessed sprite active at it (if true)
                {
                    part.SetActive(isPossessed);
                    continue;
                }
                else if (part.name == "normal")//if this is the normal sprite deactivate it (if true)
                {
                    part.SetActive(!isPossessed);
                    continue;
                }
            }
    }//end setPossessed
}
