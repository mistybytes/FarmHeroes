using System;
using System.Collections.Generic;

[Serializable]
public class ItemDTO
{
    public string Name;
    public Dictionary<Rarity,int> Items;

    public ItemDTO(Item item) 
    {
        Name = item.Data.Name;
        foreach (Rarity rarity in (Rarity[])Enum.GetValues(typeof(Rarity)))
        {
            Items[rarity] = item.Quantity[rarity];
        } 
    }
}
