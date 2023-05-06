using System;
using System.Collections.Generic;

[Serializable]
public class InventoryDTO
{
    public List<ItemDTO> Items;
    public List<AnimalDTO> Animals = new List<AnimalDTO>();
    public CurrencyDTO Currency;
    public InventoryDTO(Inventory inventory) 
    {
        Items = new List<ItemDTO>();
        foreach(Item item in inventory.Items)
        {
            
        }


        Currency = new CurrencyDTO(inventory.Currency);
        foreach (Item item in inventory.Items) 
        {
            Items.Add(new ItemDTO(item));
        }
   
        foreach (Animal animal in inventory.Animals)
        {
            Animals.Add(new AnimalDTO(animal));
        }
    }

}
