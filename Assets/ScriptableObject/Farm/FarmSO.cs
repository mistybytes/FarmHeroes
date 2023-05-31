using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Farm", menuName = "Farm/Create New Farm")]
public class FarmSO : ScriptableObject
{
    public Item Item;
    public AnimalSO Animal;

    [HideInInspector]
    public Dictionary<string, int> PlacedItems => PlacedItemsValues();

    public Dictionary<string,int> PlacedItemsValues()
    {
        Dictionary<string,int> placedItems = new Dictionary<string, int> ();
        placedItems["Common"] = 0;
        placedItems["Uncommon"] = 0;
        placedItems["Rare"]= 0;
        placedItems["Epic"] = 0;
        placedItems["Legendary"] = 0;
        return placedItems;
    }
}
