using System;

[Serializable]
public class AnimalClass
{
    public int Id;

    public AnimalSO Data;

    public int Energy;

    public int Level;
    public int Health => Data.BasicHealth * ((int)Rarity + 1) * Level;
    public int Speed => Data.BasicSpeed * ((int)Rarity + 1) * Level;
    public int Power => Data.BasicPower * ((int)Rarity + 1) * Level;
    public int Focus => Data.BasicFocus * ((int)Rarity + 1) * Level;

    public Rarity Rarity;
    public AnimalClass(Animal animal)
    {
        Id = animal.id;
        Data = animal.Data;
        Energy = animal.Energy;
        Level = animal.Level;
        Rarity = animal.rarity;

    }

}

