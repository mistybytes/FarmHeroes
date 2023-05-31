using System;

[Serializable]
public class AnimalDTO
{
    public int Id;
    public int Level;
    public string Name;
    public string Rarity;

    public AnimalDTO() { }

    public AnimalDTO(Animal animal)
    {
        Id = animal.id;
        Level= animal.Level;
        Name = animal.Data.Name;
        Rarity = animal.rarity.ToString();
    }
}
