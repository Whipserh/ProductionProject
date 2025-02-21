using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigScript : MonoBehaviour
{
    public GameObject digArea;
    public GameObject digAreaDugUp;
    public BoxCollider2D trigger;
    public MoveToClick player;

    public GameObject digNotif;

    public bool playerInDigsite = false;
    public bool areaDug = false;

    // Start is called before the first frame update
    void Start()
    {
        digArea.SetActive(true);
        digAreaDugUp.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("e") && playerInDigsite && !areaDug)
        {
            areaDug = true;
            digArea.SetActive(false);
            digAreaDugUp.SetActive(true);
            trigger.enabled = false;
            digNotif.SetActive(false);
            playerInDigsite = false;
            Debug.Log("Area dug up!");
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !areaDug)
        {
            digNotif.SetActive(true);
            playerInDigsite = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("player exit");

        if (collision.gameObject.name == "Player" && !areaDug)
        {
            digNotif.SetActive(false);
            playerInDigsite = false;
        }
    }


}
