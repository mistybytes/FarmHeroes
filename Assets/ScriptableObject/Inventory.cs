using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName ="New Inventory", menuName ="Inventory/New Inventory")]
public class Inventory : ScriptableObject
{
    
    public List<Item> Items;
    public List<AnimalClass> Animals;
    public Currency Currency;

    public Inventory (InventoryDTO inventoryDTO)
    {
        foreach(Item item in Items)
        {
            foreach(ItemDTO itemDTO in inventoryDTO.Items)
            {
                if(item.Data.Name == itemDTO.Name)
                {
                    Dictionary<Rarity, int> quantityDTO = new Dictionary<Rarity, int>();

                    foreach (string row in itemDTO.Quantity)
                    {
                        string[] strings = row.Split(':');
                        Rarity rarity = stringToRarity(strings[0]);
                        int value = int.Parse(strings[1]);
                        quantityDTO[rarity] = value;
                    }
                    item.Quantity = quantityDTO;
                }
            }
        }
    }


    public Rarity stringToRarity(string sRarity)
    {

        switch (sRarity)
        {
            case "Common":
                return Rarity.Common;
            case "Uncommon":
                return Rarity.Uncommon;
            case "Rare":
                return Rarity.Rare;
            case "Epic":
                return Rarity.Epic;
            case "Legendary":
                return Rarity.Legendary;
        }
        return Rarity.Common;
    }
}
