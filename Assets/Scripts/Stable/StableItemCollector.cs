using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Stable Item Collector", menuName = "Stable/Create New Stable Item Collector")]
public class StableItemCollector : ScriptableObject
{
    public List<ItemDTO> Items = new List<ItemDTO>();
}
