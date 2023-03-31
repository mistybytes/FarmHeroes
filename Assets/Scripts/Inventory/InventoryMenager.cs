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
    public Inventory Inventory;


    public Transform ItemContent;
    public GameObject InventoryItem;
    private bool NewItem = false;


    private void Awake()
    {
        Instance = this;

    }

    public void newItem()
    {
        NewItem = true;
    }

    private void Update()
    {
        if (NewItem)
        {
            ListItems();
            NewItem = false;
        }
    }

    public void Add (Animal animal) 
    {
        Inventory.Animals.Add(animal);
    }

    public void Remove (Item item)
    {
       // Items[item] -= 1;
    }
    public void Remove(Animal animal)
    {
        Inventory.Animals.Remove(animal);
    }

    public void ListAnimals()
    {
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }

        foreach (Animal animal in Inventory.Animals)
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
}
