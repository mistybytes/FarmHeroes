using Palmmedia.ReportGenerator.Core.Common;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class FeedMenager : MonoBehaviour
{

    public static FeedMenager Instance;
    public GameObject[] Slots;
    public GameObject ChansValus;
    public FarmSO Farm;
    public StableItemCollector StableItemCollector;
    public DataController DataController;
    public Button FeedButton;
    private void Start()
    {
        Instance = this;
        DataController.LoadInventoryData();
        DataController.LoadStableItems();
        StartValues();
        FeedButton.GetComponent<Button>().onClick.AddListener(Feed);

    }
    private void OnDisable()
    {
        DataController.SaveStableData();
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
        Dictionary<Rarity, int> quantity = new Dictionary<Rarity, int>();
        foreach (var pair in itemDTO.Quantity)
        {
            string[] row = pair.Split(":");
            string rarityString = row[0];
            int value = int.Parse(row[1]);
            Rarity rarity = stringToRarity(rarityString);
            quantity.Add(rarity, value);
        }
        commonValue.text = $"{quantity[Rarity.Common]} %";
        uncommonValue.text = $"{quantity[Rarity.Uncommon]} %";
        rareValue.text = $"{quantity[Rarity.Rare]} %";
        epicValue.text = $"{quantity[Rarity.Epic]} %";
        legenderyValue.text = $"{quantity[Rarity.Legendary]} %";

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
                    Object.Destroy(slot.transform.GetChild(i).gameObject);
                }
            }
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
