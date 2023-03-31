using System;
using System.Collections.Generic;
using UnityEngine;
using static InventoryMenager;

public class Farm : MonoBehaviour
{
    public Building Building;
    public List<Item> Items;
    public Dictionary<Rarity, double> Rarity = new Dictionary<Rarity, double>();

    private void Start()
    {
        BaseRarity();
    }


    private void SetStartChance(double common, double uncomon, double rare, double epic, double legendary) 
    {
        Rarity[InventoryMenager.Rarity.Common] = common;
        Rarity[InventoryMenager.Rarity.Uncommon] = uncomon;
        Rarity[InventoryMenager.Rarity.Rare] = rare;
        Rarity[InventoryMenager.Rarity.Epic] = epic;
        Rarity[InventoryMenager.Rarity.Legendary] = legendary;
    }

    private void SetDropChance(double common, double uncomon, double rare, double epic, double legendary)
    {
        Rarity[InventoryMenager.Rarity.Common] += common;
        Rarity[InventoryMenager.Rarity.Uncommon] += uncomon;
        Rarity[InventoryMenager.Rarity.Rare] += rare;
        Rarity[InventoryMenager.Rarity.Epic] += epic;
        Rarity[InventoryMenager.Rarity.Legendary] += legendary;
    }

    private void BaseRarity()
    {
        switch(Building.Level / 10)
        {
            case 0:
                SetStartChance(100, 0, 0, 0, 0);
                for (int i = 0; i < Building.Level; i++)
                {
                    SetDropChance(-2.5, 2.5, 0, 0, 0);
                }
                break;
            case 1:
                SetStartChance(75, 25, 0, 0, 0);
                for (int i = 0; i < Building.Level % 10; i++)
                {
                    SetDropChance(-2, 0.5, 1.5, 0, 0);
                }
                break;
            case 2:
                SetStartChance(55, 30, 15, 0, 0);
                for (int i = 0; i < Building.Level % 10; i++)
                {
                    SetDropChance(-1, 0.3, 0.5, 0.2, 0);
                }
                break;
            case 3:
                SetStartChance(45, 33, 20, 2, 0);
                for (int i = 0; i < Building.Level % 10; i++)
                {
                    SetDropChance(-2, 0.7, 1, 0.3, 0);
                }
                break;
            case 4:
                SetStartChance(25, 40, 30, 5, 0);
                for (int i = 0; i < Building.Level % 10; i++)
                {
                    SetDropChance(-0.6, -1, 0.5, 1, 0.2);
                }
                break;
            case 5:
                SetStartChance(19, 30, 35, 15, 1);

                for (int i = 0; i < Building.Level % 10; i++)
                {
                    SetDropChance(0.3, -1, 0, 1, 0.3);
                }
                break;
            case 6:
                SetStartChance(16, 20, 35, 25, 4);

                for (int i = 0; i < Building.Level % 10; i++)
                {
                    SetDropChance(-0.7, -0.5, -0.5, 0.5, 1.2);
                }
                break;
            case 7:
                SetStartChance(9, 15, 30, 30, 16);

                for (int i = 0; i < Building.Level % 10; i++)
                {
                    SetDropChance(-0.4, -0.5, -1, 1, 0.9);
                }
                break;
            case 8:
                SetStartChance(5, 10, 20, 40, 25);

                for (int i = 0; i < Building.Level % 10; i++)
                {
                    SetDropChance(-0.4, -0.8, -0.8, 1, 1);
                }
                break;
            case 9:
                SetStartChance(1, 2, 12, 50, 35);

                for (int i = 0; i < Building.Level % 10; i++)
                {
                    SetDropChance(-0.1, -0.1, -0.5, 0.5, 0.2);
                }
                break;
            case 10:
                SetStartChance(0, 1, 7, 55, 37);
                break;
        }
    }
}
