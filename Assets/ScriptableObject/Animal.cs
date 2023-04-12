using UnityEngine;

[CreateAssetMenu(fileName ="New Animal", menuName ="Animal/Create New Animal")]
public class Animal : ScriptableObject
{
    public enum AnimalType
    {
        Chicken,
        Goat,
        Cow,
        Pig,
        Rabbit
    }

    public int id;
    public string animalName;
    public int basicHealth;
    public int basicSpeed;
    public int basicPower;
    public int basicFocus;
    public int energy => 100;
    public int star;
    public int level;
    public Item.Rarity rarity;
    public AnimalType animalType;
    public Sprite icon;
    public GameObject model;
}
