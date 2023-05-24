using System;
using System.Collections.Generic;
using System.Diagnostics;

[Serializable]
public class ItemDTO
{
    public string Name;
    public List<string> Quantity = new List<string>();

    public ItemDTO() { }
    public ItemDTO(Item item) 
    {
        Name = item.Data.Name;
        foreach (Rarity rarity in (Rarity[])Enum.GetValues(typeof(Rarity)))
        {
            string record = $"{rarity}:{item.Quantity[rarity]}";
            Quantity.Add(record);
        }
        
    }
}
