using System;
using UnityEngine;
using UnityEngine.UI;
public class ListAnimals
{
    public Transform ItemContent;
    public Inventory Inventory;
    public GameObject InventoryItem;

    public ListAnimals(Transform itemContent, Inventory inventory, GameObject inventoryItem)
    {
        ItemContent = itemContent;
        Inventory = inventory;
        InventoryItem = inventoryItem;

    }
    public void CleanContent()
    {
        foreach (Transform item in ItemContent)
        {

            MonoBehaviour.Destroy(item.gameObject);
        }
    }

    public void ListAnimal()
    {
        CleanContent();

        foreach (AnimalClass animal in Inventory.Animals)
        {
            NewSlot(animal);
        }
    }

    public void NewSlot(AnimalClass animal)
    {
        GameObject obj = MonoBehaviour.Instantiate(InventoryItem, ItemContent);

        Text animalName = obj.transform.Find("Name").GetComponent<Text>();
        Text animalLevel = obj.transform.Find("Level").GetComponent<Text>();
        Image animalIcon = obj.transform.Find("Image").GetComponent<Image>();

        Transform statistic = obj.transform.Find("Statistic");

        Text animalHealth = statistic.transform.Find("Health").transform.Find("Value").GetComponent<Text>();
        Text animalPower = statistic.transform.Find("Power").transform.Find("Value").GetComponent<Text>();
        Text animalSpeed = statistic.transform.Find("Speed").transform.Find("Value").GetComponent<Text>();
        Text animalFocus = statistic.transform.Find("Focus").transform.Find("Value").GetComponent<Text>();

        Image backgraungImage = obj.transform.GetComponent<Image>();


        backgraungImage.color = RarityToColor(animal.Rarity);

        animalName.text = animal.Data.Name;
        animalLevel.text = animal.Level.ToString();
        animalIcon.sprite = animal.Data.Icon;
        animalHealth.text = animal.Health.ToString();
        animalPower.text = animal.Power.ToString();
        animalSpeed.text = animal.Speed.ToString();
        animalFocus.text = animal.Focus.ToString();
       
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
