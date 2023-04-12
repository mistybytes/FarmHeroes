using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Inventory", menuName ="Inventory/New Inventory")]
public class Inventory : ScriptableObject
{
    public List<Item> Items;
    public List<Animal> Animals;
    public Currency Currency;

}
