using System;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Specific Item")]
public class Item : ScriptableObject
{
    public int Id;
    public ItemSO Data;
    public Dictionary<Rarity, int> Quantity = new Dictionary<Rarity, int>();
}


