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
            GetItem().value += Value;
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
        float value = Random.Range(0f, 100f);
        InventoryMenager.Rarity rarity = InventoryMenager.Rarity.Uncommon;

        if (value > 0 && value < 1)
        {
            rarity = InventoryMenager.Rarity.Common;
            return GetSpecificItem(rarity);
        }
        if (value > 0 && value < 1)
        {
            rarity = InventoryMenager.Rarity.Rare;
            return GetSpecificItem(rarity);
        }
        if (value > 0 && value < 1)
        {
            rarity = InventoryMenager.Rarity.Epic;
            return GetSpecificItem(rarity);
        }
        if (value > 0 && value < 1)
        {
            rarity = InventoryMenager.Rarity.Legendary;
            return GetSpecificItem(rarity);
        }
        if (value > 0 && value < 1)
        {
            rarity = InventoryMenager.Rarity.Divine;
            return GetSpecificItem(rarity);
        }
        return GetSpecificItem(rarity);
    }

    private Item GetSpecificItem(InventoryMenager.Rarity rarity) 
    {
        foreach (Item item in Farm.Items)
        {
            if (item.rarity == InventoryMenager.Rarity.Uncommon)
            {
                return item;
            }
            if (item.rarity == InventoryMenager.Rarity.Common)
            {
                return item;
            }
            if (item.rarity == InventoryMenager.Rarity.Rare)
            {
                return item;
            }
            if (item.rarity == InventoryMenager.Rarity.Epic)
            {
                return item;
            }
            if (item.rarity == InventoryMenager.Rarity.Legendary)
            {
                return item;
            }
            if (item.rarity == InventoryMenager.Rarity.Divine)
            {
                return item;
            }
        }
        return null;
    }
}
