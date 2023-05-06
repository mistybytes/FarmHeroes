using System.Collections.Generic;
using UnityEngine;

public class Farm : MonoBehaviour
{
    public Building Building;
    public Item Item;
    public Dictionary<Rarity, float> DropChance = new Dictionary<Rarity, float>();

    void Start()
    {
        BaseRarity();
    }


    private void SetStartChance(float common, float uncomon, float rare, float epic, float legendary) 
    {
        DropChance[Rarity.Common] = common;
        DropChance[Rarity.Uncommon] = uncomon;
        DropChance[Rarity.Rare] = rare;
        DropChance[Rarity.Epic] = epic;
        DropChance[Rarity.Legendary] = legendary;
    }

    private void SetDropChance(float common, float uncomon, float rare, float epic, float legendary)
    {
        DropChance[Rarity.Common] += common;
        DropChance[Rarity.Uncommon] += uncomon;
        DropChance[Rarity.Rare] += rare;
        DropChance[Rarity.Epic] += epic;
        DropChance[Rarity.Legendary] += legendary;
    }

    private void BaseRarity()
    {
        switch(Building.Level / 10)
        {
            case 0:
                SetStartChance(100, 0, 0, 0, 0);
                for (int i = 0; i < Building.Level; i++)
                {
                    SetDropChance(-2.5f, 2.5f, 0, 0, 0);
                }
                break;
            case 1:
                SetStartChance(75, 25, 0, 0, 0);
                for (int i = 0; i < Building.Level % 10; i++)
                {
                    SetDropChance(-2, 0.5f, 1.5f, 0, 0);
                }
                break;
            case 2:
                SetStartChance(55, 30, 15, 0, 0);
                for (int i = 0; i < Building.Level % 10; i++)
                {
                    SetDropChance(-1, 0.3f, 0.5f, 0.2f, 0);
                }
                break;
            case 3:
                SetStartChance(45, 33, 20, 2, 0);
                for (int i = 0; i < Building.Level % 10; i++)
                {
                    SetDropChance(-2, 0.7f, 1, 0.3f, 0);
                }
                break;
            case 4:
                SetStartChance(25, 40, 30, 5, 0);
                for (int i = 0; i < Building.Level % 10; i++)
                {
                    SetDropChance(-0.6f, -1, 0.5f, 1, 0.2f);
                }
                break;
            case 5:
                SetStartChance(19, 30, 35, 15, 1);

                for (int i = 0; i < Building.Level % 10; i++)
                {
                    SetDropChance(0.3f, -1, 0, 1, 0.3f);
                }
                break;
            case 6:
                SetStartChance(16, 20, 35, 25, 4);

                for (int i = 0; i < Building.Level % 10; i++)
                {
                    SetDropChance(-0.7f, -0.5f, -0.5f, 0.5f, 1.2f);
                }
                break;
            case 7:
                SetStartChance(9, 15, 30, 30, 16);

                for (int i = 0; i < Building.Level % 10; i++)
                {
                    SetDropChance(-0.4f, -0.5f, -1, 1, 0.9f);
                }
                break;
            case 8:
                SetStartChance(5, 10, 20, 40, 25);

                for (int i = 0; i < Building.Level % 10; i++)
                {
                    SetDropChance(-0.4f, -0.8f, -0.8f, 1, 1);
                }
                break;
            case 9:
                SetStartChance(1, 2, 12, 50, 35);

                for (int i = 0; i < Building.Level % 10; i++)
                {
                    SetDropChance(-0.1f, -0.1f, -0.5f, 0.5f, 0.2f);
                }
                break;
            case 10:
                SetStartChance(0, 1, 7, 55, 37);
                break;
        }
    }
}
