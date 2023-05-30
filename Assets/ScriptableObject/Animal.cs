using System;
using UnityEngine;
[CreateAssetMenu(fileName = "New Animal", menuName = "Animal/Create New SpecificAnimal")]
public class Animal : ScriptableObject
{ 
    public int id;

    public AnimalSO Data;

    public int Energy;

    public int Level;
    public int Health => Data.BasicHealth * ((int)rarity + 1) * Level;
    public int Speed => Data.BasicSpeed * ((int)rarity + 1) * Level;
    public int Power => Data.BasicPower * ((int)rarity + 1) * Level;
    public int Focus => Data.BasicFocus * ((int)rarity + 1) * Level;

    public Rarity rarity;

}
