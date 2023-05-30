using System;

[Serializable]
public class AnimalDTO
{
    public int Id;
    public int Level;
    public string Name;
    public string Rarity;

    public AnimalDTO(AnimalClass animal)
    {
        Id = animal.Id;
        Level= animal.Level;
        Name = animal.Data.Name;
        Rarity = animal.Rarity.ToString();
    }
}
