using Palmmedia.ReportGenerator.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class FeedMenager : MonoBehaviour
{

    public static FeedMenager Instance;
    public GameObject[] Slots;
    public GameObject ChansValus;
    public FarmSO Farm;
    public DataController DataController;
    public Inventory Inventory;
    public Text Quantity;
    private int FeedQuantity;


    public int MaxQuantityOfPlant = 60;
    private Dictionary<Rarity,int> stableRarity = new Dictionary<Rarity,int>();
    private void Start()
    {
        Instance = this;
        DataController.LoadInventoryData();
        DataController.LoadStableItems();
        StartValues();

    }
    private void OnDisable()
    {
        DataController.SaveStableData();
    }

    void AddNewAnimal()
    {
        for (int i = 0; i < MaxQuantityOfPlant; i++)
        {
            float value = UnityEngine.Random.Range(0, MaxQuantityOfPlant);
            float commonDrop = stableRarity[Rarity.Common];
            float uncommonDrop = commonDrop + stableRarity[Rarity.Uncommon];
            float rareDrop = commonDrop + stableRarity[Rarity.Rare];
            float epicDrop = rareDrop + stableRarity[Rarity.Epic];
            float legendaryDrop = epicDrop + stableRarity[Rarity.Legendary];

            if (value < commonDrop)
            {
                AddAnimal(Rarity.Common);
            }
            if (value >= commonDrop && value < uncommonDrop)
            {
                AddAnimal(Rarity.Uncommon);
            }
            if (value >= uncommonDrop && value < rareDrop)
            {
                AddAnimal(Rarity.Rare);
            }
            if (value >= rareDrop && value < epicDrop)
            {
                AddAnimal(Rarity.Epic);
            }
            if (value >= epicDrop && value <= legendaryDrop)
            {
                AddAnimal(Rarity.Legendary);
            }
        }
    }

    void AddAnimal(Rarity rarity)
    {
        int id = Guid.NewGuid().ToString().ParseLargeInteger();
        Animal animalData = Farm.Animals.FirstOrDefault(animalS => animalS.rarity == rarity);
        AnimalClass animal = new AnimalClass(animalData);
        animal.Id = id;
        Inventory.Animals.Add(animal);

    }

    void StartValues()
    {
        string plantName = Farm.Item.Data.Name;

        DataController.LoadStableItems();

        Text commonValue = ChansValus.transform.Find("Common").GetChild(0).GetComponent<Text>();
        Text uncommonValue = ChansValus.transform.Find("Uncommon").GetChild(0).GetComponent<Text>();
        Text rareValue = ChansValus.transform.Find("Rare").GetChild(0).GetComponent<Text>();
        Text epicValue = ChansValus.transform.Find("Epic").GetChild(0).GetComponent<Text>();
        Text legenderyValue = ChansValus.transform.Find("Legendary").GetChild(0).GetComponent<Text>();
        

        ItemDTO itemDTO = DataController.GetStableItems().Items.FirstOrDefault(item => item.Name.Equals(plantName));

        foreach (var pair in itemDTO.Quantity)
        {
            string[] row = pair.Split(":");
            string rarityString = row[0];
            int value = int.Parse(row[1]);
            Rarity rarity = stringToRarity(rarityString);
            if (stableRarity.ContainsKey(rarity))
            {
                stableRarity[rarity] = value;
            }
            else
            {
                stableRarity.Add(rarity, value);
            }
        }

        commonValue.text = $"{stableRarity[Rarity.Common]} %";
        uncommonValue.text = $"{stableRarity[Rarity.Uncommon]} %";
        rareValue.text = $"{stableRarity[Rarity.Rare]} %";
        epicValue.text = $"{stableRarity[Rarity.Epic]} %";
        legenderyValue.text = $"{stableRarity[Rarity.Legendary]} %";
        QuantityFeed();
    }


    private void QuantityFeed()
    {
        Text quantity = Quantity.GetComponent<Text>();
        foreach (Rarity rarity in (Rarity[])Enum.GetValues(typeof(Rarity)))
        {
           FeedQuantity += stableRarity[rarity];
        }
        quantity.text = $"{FeedQuantity}/{MaxQuantityOfPlant}";
    }

    public Rarity stringToRarity(string sRarity)
    {

        switch (sRarity)
        {
            case "Common":
                return Rarity.Common;
            case "Uncommon":
                return Rarity.Uncommon;
            case "Rare":
                return Rarity.Rare;
            case "Epic":
                return Rarity.Epic;
            case "Legendary":
                return Rarity.Legendary;
        }
        return Rarity.Common;
    }

    public void Feed()
    {
        foreach (GameObject slot in Slots)
        {
            if (slot.transform.childCount > 0)
            {
                Transform children = slot.transform.GetChild(0);
                Text itemName = children.transform.Find("ItemName").GetComponent<Text>();
                Text itemCount = children.transform.Find("ItemCount").GetComponent<Text>();
                Image imageChildren = children.GetComponent<Image>();
                Rarity itemRarity = ImageColorToRarity(imageChildren);
                DataController.AddItemToStable(itemName.text, itemRarity, int.Parse(itemCount.text));
                StartValues();
                for (var i = slot.transform.childCount - 1; i >= 0; i--)
                {
                    UnityEngine.Object.Destroy(slot.transform.GetChild(i).gameObject);
                }
            }
        }
        if (FeedQuantity >= MaxQuantityOfPlant)
        {
            AddNewAnimal();
            FeedQuantity -= MaxQuantityOfPlant;
            QuantityFeed();
        }
    }

    private Rarity ImageColorToRarity(Image image)
    {
        if (image.color == Color.white)
        {
            return Rarity.Uncommon;
        }
        else if (image.color == Color.green)
        {
            return Rarity.Rare;
        }
        else if (image.color == Color.blue)
        {
            return Rarity.Epic;
        }
        else if (image.color == Color.yellow)
        {
            return Rarity.Legendary;
        }
        return Rarity.Common;
    }
}
