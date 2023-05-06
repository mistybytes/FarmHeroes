using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName ="New Inventory", menuName ="Inventory/New Inventory")]
public class Inventory : ScriptableObject
{
    
    public List<Item> Items;
    public List<Animal> Animals;
    public Currency Currency;

    public Inventory (InventoryDTO inventoryDTO)
    {
        foreach(Item item in Items)
        {
            foreach(ItemDTO itemDTO in inventoryDTO.Items)
            {

            }
        }
    }
}
