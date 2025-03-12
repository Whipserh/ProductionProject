using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public bool[] equiped = new bool[4];
    public bool[] hasInInventory = new bool[4];
    public GameObject[] images = new GameObject[4];  


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void unequip()
    {
        for(int i = 0; i < equiped.Length; i++)
        {
            equiped[i] = false;
        }
    }

    public void selectedItem1()
    {
        
    }
    public void selectedItem2()
    {

    }
    public void selectedItem3()
    {


    }
    public void selectedItem4()
    {

    }



}
