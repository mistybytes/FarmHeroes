using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalsMenager : MonoBehaviour
{
    public static AnimalsMenager Instance;
    public Inventory Inventory;
    public Transform ItemContent;
    public GameObject InventoryAnimal;
    private ListAnimals Contetn;
    private bool NewItem = false;


    private void Awake()
    {
        Instance = this;
        Contetn = new ListAnimals(ItemContent, Inventory, InventoryAnimal);
    }

    public void newItem()
    {
        NewItem = true;
    }

    private void Update()
    {
        if (NewItem)
        {
            Contetn.ListAnimal();
            NewItem = false;
        }
    }

    public void ListAnimals()
    {
        Contetn.ListAnimal();
    }

}
