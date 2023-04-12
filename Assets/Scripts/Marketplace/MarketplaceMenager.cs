using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarketplaceMenager : MonoBehaviour
{
    public static MarketplaceMenager Instance;
    public GameObject Viev,Sale, Buy, InventoryItem;
    public Inventory Inventory;

    public Transform ItemContent;

    public List<Item> SaleList = new List<Item>();


    private bool wosInvoke = false; 

    private void Start()
    {
        Instance = this;
        Button sell = Sale.GetComponent<Button>();
        sell.onClick.AddListener(SellButton);
        Button buy = Buy.GetComponent<Button>();
        buy.onClick.AddListener(BuyButton);
    }

    private void Update()
    {
        if (wosInvoke)
        {
            ListItems();
        }
    }

    void SellButton()
    {
        Sale.SetActive(false);
        Buy.SetActive(true);
        ListItems();
    }

    void BuyButton()
    {
        CleanContent();
        Buy.SetActive(false);
        Sale.SetActive(true);
    }


    void CleanContent()
    {
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }
    }

    public void ListItems()
    {
        CleanContent();

        foreach (Item item in Inventory.Items)
        {
            if (item.value > 0)
            {
                int slotCaunt = 30;
                int backpackItemCaunt = item.value;

                while (backpackItemCaunt > slotCaunt)
                {
                    backpackItemCaunt -= slotCaunt;
                    NewSlot(item, slotCaunt);
                }

                NewSlot(item, backpackItemCaunt);
            }
        }
        wosInvoke = false;
    }

    public void NewSlot(Item item, int slotCaunt)
    {
        GameObject obj = Instantiate(InventoryItem, ItemContent);
        Text itemName = obj.transform.Find("ItemName").GetComponent<Text>();
        Image itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
        Text itemCount = obj.transform.Find("ItemCount").GetComponent<Text>();

        itemName.text = item.itemName;
        itemIcon.sprite = item.icon;
        itemCount.text = slotCaunt.ToString();
    }

    public void Invoke()
    {
        wosInvoke = true;
    }

}


