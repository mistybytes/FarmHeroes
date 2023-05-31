using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName ="New Inventory", menuName ="Inventory/New Inventory")]
public class Inventory : ScriptableObject
{
    public List<Item> Items;
    public List<Animal> Animals;
    public Currency Currency;
    public List<AnimalSO> AnimalsSo;

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
        foreach (AnimalDTO animalDTO in inventoryDTO.Animals)
        {
            Animal animal = AnimalDTOToAnimal(animalDTO);
            Animals.Add(animal);
        }
        Currency.Coin = inventoryDTO.Currency.Coin;
        Currency.Diamond = inventoryDTO.Currency.Diamond;
    }

    Animal AnimalDTOToAnimal(AnimalDTO animalDTO)
    {
        AnimalSO animalSO = AnimalsSo.FirstOrDefault(animal => animal.Name.Equals(animalDTO.Name));

        return new Animal()
        {
            id = animalDTO.Id,
            Data = animalSO,
            Energy = 0,
            Level = animalDTO.Level,
            rarity = stringToRarity(animalDTO.Rarity),
        };
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
