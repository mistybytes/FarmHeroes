using System;
using UnityEngine;
using UnityEngine.UI;

public class ListItems 
{
    public Transform ItemContent;
    public Inventory Inventory;
    public GameObject InventoryItem;

    public ListItems(Transform itemContent, Inventory inventory,GameObject inventoryItem) 
    {
        ItemContent = itemContent;
        Inventory = inventory;
        InventoryItem = inventoryItem;

    }
    int ItemValue(Item item, Rarity rarity)
    {
        return item.Quantity[rarity];
    }
    public void CleanContent()
    {
        foreach (Transform item in ItemContent)
        {
            
            MonoBehaviour.Destroy(item.gameObject);
        }
    }

    public void ListItem() 
    {
        CleanContent();

        foreach (Item item in Inventory.Items)
        {
            foreach (Rarity rarity in (Rarity[])Enum.GetValues(typeof(Rarity)))
            {
                if (ItemValue(item, rarity) > 0)
                {
                    int slotCaunt = 30;
                    int backpackItemCaunt = ItemValue(item, rarity);

                    while (backpackItemCaunt > slotCaunt)
                    {
                        backpackItemCaunt -= slotCaunt;
                        NewSlot(item, slotCaunt, rarity);
                    }

                    NewSlot(item, backpackItemCaunt, rarity);
                }
            }
        }
    }

    public void NewSlot(Item item, int slotCaunt, Rarity rarity)
    {
        GameObject obj = MonoBehaviour.Instantiate(InventoryItem, ItemContent);
        Text itemName = obj.transform.Find("ItemName").GetComponent<Text>();
        Image itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
        Text itemCount = obj.transform.Find("ItemCount").GetComponent<Text>();
        Image backgraungImage = obj.transform.GetComponent<Image>();

        backgraungImage.color = RarityToColor(rarity);
        itemName.text = item.Data.Name;
        itemIcon.sprite = item.Data.Icon;
        itemCount.text = slotCaunt.ToString();
    }

    private Color RarityToColor(Rarity rarity)
    {
        switch (rarity)
        {
            case Rarity.Common:
                return Color.white;
            case Rarity.Rare:
                return Color.green;
            case Rarity.Epic:
                return Color.blue;
            case Rarity.Legendary:
                return Color.yellow;

        }
        return Color.gray;
    }
}


