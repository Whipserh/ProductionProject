using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GhostTrap : MonoBehaviour
{



    public BoxCollider2D trigger;
    public MoveToClick player;

    public Inventory inv;

    public int nextRoom = 2;

    // 8 bit fading
    public GameObject fade1;
    public GameObject fade2;
    public GameObject fade3;

 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "Ghost")
        {


            SceneManager.LoadScene(nextRoom);
        }
    }

    private IEnumerator FadeOut()
    {

        fade1.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        fade2.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        fade3.SetActive(true);
        SceneManager.LoadScene(nextRoom);
    }

    private IEnumerator FadeIn()
    {

        yield return new WaitForSeconds(0.3f);
        fade3.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        fade2.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        fade1.SetActive(false);

        Debug.Log("we good");
    }
}
