using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEditor.UIElements;

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


    private void Awake()
    {
        Instance = this;
    }

    public void Add (Item item)
    {

        if (Items.Contains(item))
        {
            foreach (Item inventoryItem in Items)
            {
                if (item.itemName == inventoryItem.itemName && item.rarity == inventoryItem.rarity)
                {
                    item.value += item.value;
                }
            }
        }
        else
        {
            Item newItem = new Item()
            {
                id = item.id,
                itemName = item.itemName,
                value = item.value,
                icon = item.icon,
                rarity = item.rarity,
            };

            Items.Add(newItem);
        }
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
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            
            Text itemName = obj.transform.Find("ItemName").GetComponent<Text>();
            Image itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
            Text itemCount = obj.transform.Find("ItemCount").GetComponent<Text>();

            
            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;
            itemCount.text = item.value.ToString();

        }
    }

}
