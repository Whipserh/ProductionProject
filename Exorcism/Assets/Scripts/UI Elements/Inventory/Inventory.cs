using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{

    public bool[] equiped = new bool[4];
    public bool[] hasInInventory = new bool[4];
    public GameObject[] images = new GameObject[4];  


    // prime added this stuff for the playtest build, feel free to edit / remove / fix anything
    public void GetKeycard()
    {
        images[0].SetActive(true);
        hasInInventory[0] = true;
    }

    public void GetTrap()
    {
        images[1].SetActive(true);
        hasInInventory[1] = true;
    }

    public void PlaceTrap()
    {
        images[1].SetActive(false);
        hasInInventory[1] = false;
    }


    //sets all the items to bools
    public void unequip()
    {
        for(int i = 0; i < equiped.Length; i++)
        {
            equiped[i] = false;
        }
    }

    public void selectedItem1()
    {
        equipItem(0);
    }
    public void selectedItem2()
    {
        equipItem(1);
    }
    public void selectedItem3()
    {
        equipItem(2);
    }
    public void selectedItem4()
    {
        equipItem(3);
    }

    //takes an inventory index and activates it
    public void equipItem(int index)
    {
        unequip();
        if (hasInInventory[index])
        {
            equiped[index] = true;
            Debug.Log($"Player equiped {images[index].name}");
        }
    }

    //returns the string that the player has equiped
    public string getEquipedItem()
    {
        for(int i = 0; i < hasInInventory.Length; i++)
        {
            if (hasInInventory[i] && equiped[i]) return images[i].GetComponent<UnityEngine.UI.Image>().sprite.name;
        }
        return "";
    }

}
