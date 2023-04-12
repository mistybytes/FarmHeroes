using UnityEngine;

public class Chicken : MonoBehaviour
{
    public Animal animal;

    private int Health;
    private int Speed;
    private int Power;
    private int Focus;

    private void Awake()
    {
        Health = animal.basicHealth * animal.level * animal.star * AnimalRarityToInt();
        Speed = animal.basicSpeed * animal.level * animal.star * AnimalRarityToInt();
        Power = animal.basicPower * animal.level * animal.star * AnimalRarityToInt();
        Focus = animal.basicFocus * animal.level * animal.star * AnimalRarityToInt();
    }


    private int AnimalRarityToInt()
    {
        switch (animal.rarity)
        {
            case Item.Rarity.Common:
                return 1;
            case Item.Rarity.Uncommon:
                return 2;
            case Item.Rarity.Rare:
                return 3;
            case Item.Rarity.Epic:
                return 4;
            case Item.Rarity.Legendary:
                return 5;
        }
        return 0;
    }

}
