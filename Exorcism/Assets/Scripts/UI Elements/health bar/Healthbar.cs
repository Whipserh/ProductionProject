using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthbar : MonoBehaviour
{

    public GameObject [] healthBars = new GameObject[6];

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < healthBars.Length; i++)
        {
            healthBars[i].SetActive(false);
        }
        tempHealth = 2;
        setHealth(health);
    }

    // Update is called once per frame
    void Update()
    {
        /**
        if (Input.GetKeyDown(KeyCode.A))
        {
            tempHealth--;
            setHealth(tempHealth);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            tempHealth++;
            setHealth(tempHealth);
        }**/
    }
    private int tempHealth;
    private int health = 2;

    public void setHealth(int newHealth)
    {
        if (newHealth > healthBars.Length - 1) newHealth = healthBars.Length - 1;
        if (newHealth < 0) newHealth = 0;
        healthBars[health].SetActive(false);//turn of the old health bar off
        healthBars[newHealth].SetActive(true);//turn the new health bar on
        health = newHealth;
    }

    public int getHealh()
    {
        return health;
    }
}
