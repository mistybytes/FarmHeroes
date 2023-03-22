using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMenager : MonoBehaviour
{
    public enum Rarity
    {
        Common,
        Uncommon,
        Rare,
        Epic,
        Legendary,
        Divine,
    }


    public static InventoryMenager Instance;
    public List<Item> Items = new List<Item>();
    public List<Animal> Animals = new List<Animal>();


    public Transform ItemContent;
    public GameObject InventoryItem;
    private bool NewItem = false;


    private void Awake()
    {
        Instance = this;

    }

    private void Update()
    {
        if (NewItem)
        {
            ListItems();
            NewItem = false;
        }
    }

    public void Add (Item newItem)
    {
        Item backpackItem = Items.Find(item => item.id == newItem.id);

        if (backpackItem == null && newItem.value > 0)
        {
            Item item = new Item()
            {
                id = newItem.id,
                itemName = newItem.name,
                value = newItem.value,
                icon = newItem.icon,
                rarity = newItem.rarity,
            };

            Items.Add(item);
        }
        else if (newItem.value > 0)
        {
            backpackItem.value += newItem.value;
        }
        NewItem = true;
    }


    public void Add (Animal animal) 
    {
        Animals.Add(animal);
    }

    public void Remove (Item item)
    {
       // Items[item] -= 1;
    }
    public void Remove(Animal animal)
    {
        Animals.Remove(animal);
    }

    public void ListAnimals()
    {
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }

        foreach (Animal animal in Animals)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);

            Text itemName = obj.transform.Find("ItemName").GetComponent<Text>();
            Image itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();

            itemName.text = animal.animalName;
            itemIcon.sprite = animal.icon;

        }
    }

    public void ListItems () 
    {
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }

        foreach (Item item in Items)
        {
            int slotCaunt = 30;
            int backpackItemCaunt = item.value;

            while (backpackItemCaunt > slotCaunt)
            {
                backpackItemCaunt -= slotCaunt;

                GameObject obj = Instantiate(InventoryItem, ItemContent);
                Text itemName = obj.transform.Find("ItemName").GetComponent<Text>();
                Image itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
                Text itemCount = obj.transform.Find("ItemCount").GetComponent<Text>();

                itemName.text = item.itemName;
                itemIcon.sprite = item.icon;
                itemCount.text = slotCaunt.ToString();
            }

            GameObject objR = Instantiate(InventoryItem, ItemContent);
            Text itemNameR = objR.transform.Find("ItemName").GetComponent<Text>();
            Image itemIconR = objR.transform.Find("ItemIcon").GetComponent<Image>();
            Text itemCountR = objR.transform.Find("ItemCount").GetComponent<Text>();

            itemNameR.text = item.itemName;
            itemIconR.sprite = item.icon;
            itemCountR.text = backpackItemCaunt.ToString();


        }
    }

}
