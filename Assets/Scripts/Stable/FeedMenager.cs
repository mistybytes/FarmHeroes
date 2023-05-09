using Palmmedia.ReportGenerator.Core.Common;
using System.Collections.Generic;
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
    private void Start()
    {
        Instance = this;
        StartValues();
    }

    void StartValues()
    {
        DataController.LoadStableItems();
        string plantName = Farm.Item.Data.Name;
        List<ItemDTO> stableItems = DataController.GetStableItems();
        Text commonValue = ChansValus.transform.Find("Common").GetChild(0).GetComponent<Text>();
        Text uncommonValue = ChansValus.transform.Find("Uncommon").GetChild(0).GetComponent<Text>();
        Text rareValue = ChansValus.transform.Find("Rare").GetChild(0).GetComponent<Text>();
        Text epicValue = ChansValus.transform.Find("Epic").GetChild(0).GetComponent<Text>();
        Text legenderyValue = ChansValus.transform.Find("Legendary").GetChild(0).GetComponent<Text>();

        foreach (ItemDTO itemDTO in stableItems)
        {
            if (itemDTO.Name == plantName)
            {
       //         commonValue.text = $"{itemDTO.Items[Rarity.Common]} %";
         //       uncommonValue.text = $"{itemDTO.Items[Rarity.Uncommon]} %";
       //         rareValue.text = $"{itemDTO.Items[Rarity.Rare]} %";
       //         epicValue.text = $"{itemDTO.Items[Rarity.Epic]} %";
       //         legenderyValue.text = $"{itemDTO.Items[Rarity.Legendary]} %";
            }
        }
    }


    public void Feed()
    {
        foreach (GameObject slot in Slots)
        {
            if (slot.transform.GetChild(0) != null)
            {
                Transform children = slot.transform.GetChild(0);
                Text itemName = children.transform.Find("ItemName").GetComponent<Text>();
                Text itemCount = children.transform.Find("ItemCount").GetComponent<Text>();
                Image imageChildren = children.GetComponent<Image>();
                Rarity itemRarity = ImageColorToRarity(imageChildren);
                Destroy(children);
            }
        }
    }

    private void ChanceCalculator()
    {

        foreach (GameObject slot in Slots)
        {
            if (slot.transform.GetChild(0) != null)
            {
                Transform item = slot.transform.GetChild(0);
                int itemCount = item.transform.Find("ItemCount").GetComponent<Text>().text.ParseLargeInteger();
                Image imageChildren = item.GetComponent<Image>();
                Rarity itemRarity = ImageColorToRarity(imageChildren);


            }
        }

    }


    

    private float ProcentOfTotal(int totalQuantiti, int itemQuantiti)
    {
        return (float) (itemQuantiti / totalQuantiti) * 100;
    }

    private int TotalQuantitiItems()
    {
        int total = 0;
        foreach(GameObject slot in Slots)
        {
            Transform child = slot.transform.GetChild(0);
            int itemCount = child.Find("ItemCount").GetComponent<Text>().text.ParseLargeInteger();
            total += itemCount;
        }
        return total;
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
