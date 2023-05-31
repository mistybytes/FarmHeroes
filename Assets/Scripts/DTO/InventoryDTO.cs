using System;
using System.Collections.Generic;

[Serializable]
public class InventoryDTO
{
    public List<ItemDTO> Items = new List<ItemDTO>();
    public List<AnimalDTO> Animals = new List<AnimalDTO>();
    public CurrencyDTO Currency = new CurrencyDTO();

    public InventoryDTO() { }
    public InventoryDTO(Inventory inventory) 
    {
        foreach(Item item in inventory.Items)
        {
            ItemDTO itemDTO = new ItemDTO(item);
            Items.Add(itemDTO);
        }
        Currency = new CurrencyDTO(inventory.Currency);
        foreach (Animal animal in inventory.Animals)
        {
            if (animal != null)
            {
                Animals.Add(new AnimalDTO(animal));
            }
        }
    }

}
