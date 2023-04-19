using System.Collections;
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
                GetItem().value += 1;
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

    private Item GetItem()
    {
        float value = (float)Random.Range(0, 1000) / 10;
        float uncommonDrop = Farm.Rarity[Item.Rarity.Uncommon];
        float commonDrop = uncommonDrop + Farm.Rarity[Item.Rarity.Common];
        float rareDrop = commonDrop + Farm.Rarity[Item.Rarity.Rare];
        float epicDrop = rareDrop + Farm.Rarity[Item.Rarity.Epic];
        float legendaryDrop = epicDrop + Farm.Rarity[Item.Rarity.Legendary];

        if (value > uncommonDrop && value < commonDrop)
        {
            return GetSpecificItem(Item.Rarity.Common);
        }
        if (value >= commonDrop && value < rareDrop)
        {
            return GetSpecificItem(Item.Rarity.Rare);
        }
        if (value >= rareDrop && value < epicDrop)
        {
            return GetSpecificItem(Item.Rarity.Epic);
        }
        if (value >= epicDrop && value <= legendaryDrop)
        {
            return GetSpecificItem(Item.Rarity.Legendary);
        }

        return GetSpecificItem(Item.Rarity.Uncommon);
    }

    private Item GetSpecificItem(Item.Rarity rarity) 
    {
        foreach (Item item in Farm.Items)
        {
            if (item.rarity == rarity)
            {
                return item;
            }
        }
        return null;
    }
}
