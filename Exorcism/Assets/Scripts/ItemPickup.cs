using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public GameObject tableWithItem;
    public GameObject tableWithoutItem;
    public BoxCollider2D trigger;
    public MoveToClick player;

    public Inventory inv;

    public GameObject invGet;

    // 8 bit fading
    public GameObject itemNotif1;
    public GameObject itemNotif2;
    public GameObject itemNotif3;

    public GameObject hint1;
    public GameObject hint2;
    public GameObject hint3;

    public int itemType = 1;

    // Start is called before the first frame update
    void Start()
    {
        tableWithItem.SetActive(true);
        tableWithoutItem.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);

        // if item is collected...
        if (collision.gameObject.name == "Player" && itemType == 1) 
        {
            Debug.Log("Item acquired!");
            trigger.enabled = false;
            tableWithItem.SetActive(false);
            tableWithoutItem.SetActive(true);
            //  player.GetKeycard();

            inv.GetKeycard();

            // TELEMETRY
            TelemetryLogger.Log(this, "GotKeycard");

            invGet.SetActive(true); //notif

            StartCoroutine(ItemNotification());
            StartCoroutine(KeyHint());
        }


        // if item is collected...
        if (collision.gameObject.name == "Player" && itemType == 2)
        {
            Debug.Log("Item acquired!");
            trigger.enabled = false;
            tableWithItem.SetActive(false);
            tableWithoutItem.SetActive(true);
            //  player.GetKeycard();

            inv.GetTrap();

            invGet.SetActive(true); //notif

            StartCoroutine(ItemNotification());
            StartCoroutine(KeyHint());
        }

    }

    private IEnumerator ItemNotification()
    {
    
            itemNotif1.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            itemNotif2.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            itemNotif3.SetActive(true);


            yield return new WaitForSeconds(1.75f);
            itemNotif3.SetActive(false);
            yield return new WaitForSeconds(0.2f);
            itemNotif2.SetActive(false);
            yield return new WaitForSeconds(0.2f);
            itemNotif1.SetActive(false);
    }

    private IEnumerator KeyHint()
    {
        while (true)
        {

            yield return new WaitForSeconds(0.2f);
            hint1.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            hint2.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            hint3.SetActive(true);


            yield return new WaitForSeconds(0.2f);
            hint3.SetActive(false);
            yield return new WaitForSeconds(0.2f);
            hint2.SetActive(false);
            yield return new WaitForSeconds(0.2f);
            hint1.SetActive(false);

        }
        
    }

}
