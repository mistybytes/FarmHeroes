using System;

[Serializable]
public class AnimalDTO
{
    public int Id;
    public int Level;
    public string Rarity;

    public AnimalDTO(Animal animal)
    {
        Id = animal.id;
        Level= animal.Data.Level;
        Rarity = animal.rarity.ToString();
    }
}
