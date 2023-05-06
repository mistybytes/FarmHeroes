using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public Farm Farm;
    private int Value;
    

    private void Start()
    {
        Value = 0;
        StartCoroutine(EnableTimedBonus());
    }

    public int GetValue()
    {
        return Value;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            for (int i = 0; i < Value; i++)
            {
                UpdateItemValue();
            }
            InventoryMenager.Instance.newItem();
            Value = 0;
        }
    }

    IEnumerator EnableTimedBonus()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            if (Value < 60)
            {
                Value += 1;
            }
        }
    }

    private void UpdateItemValue()
    {
        float value = (float)UnityEngine.Random.Range(0, 1000) / 10;
        float commonDrop = Farm.DropChance[Rarity.Common];
        float uncommonDrop = commonDrop + Farm.DropChance[Rarity.Uncommon];
        float rareDrop = commonDrop + Farm.DropChance[Rarity.Rare];
        float epicDrop = rareDrop + Farm.DropChance[Rarity.Epic];
        float legendaryDrop = epicDrop + Farm.DropChance[Rarity.Legendary];

        if (value < commonDrop )
        {
            addOrUpdate(Farm.Item.Quantity, Rarity.Common, 1);
        }
        if (value >= commonDrop && value < uncommonDrop)
        {
            addOrUpdate(Farm.Item.Quantity, Rarity.Uncommon, 1);
        }
        if (value >= uncommonDrop && value < rareDrop)
        {
            addOrUpdate(Farm.Item.Quantity, Rarity.Rare, 1);
        }
        if (value >= rareDrop && value < epicDrop)
        {
            addOrUpdate(Farm.Item.Quantity, Rarity.Epic, 1);
        }
        if (value >= epicDrop && value <= legendaryDrop)
        {
            addOrUpdate(Farm.Item.Quantity, Rarity.Legendary, 1);
        }
        UpdateItem();
    }

    void addOrUpdate(Dictionary<Rarity, int> dic, Rarity key, int newValue)
    {
        int val;
        if (dic.TryGetValue(key, out val))
        {
            dic[key] = val + newValue;
        }
        else
        {
            dic.Add(key, newValue);
        }
    }

    void UpdateItem()
    {
        if (Farm.Item.Quantity.Count < 5)
        {
            foreach (Rarity rarity in (Rarity[])Enum.GetValues(typeof(Rarity)))
            {
                if (!Farm.Item.Quantity.ContainsKey(rarity))
                {
                    Farm.Item.Quantity.Add(rarity, 0);
                }
            }
        }
    }
}
