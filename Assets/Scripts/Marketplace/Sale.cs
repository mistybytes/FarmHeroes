using Palmmedia.ReportGenerator.Core.Common;
using UnityEngine;
using UnityEngine.UI;

public class Sale : MonoBehaviour
{
    public GameObject[] slots = new GameObject[3];
    public GameObject SaleButton;
    public Currency currency;
    public Coin coin;
    public Inventory inventory;

    private void Start()
    {
        Button button =  SaleButton.GetComponent<Button>();
        button.onClick.AddListener(Purchace);
    }

    void Purchace()
    { 
        foreach (GameObject slot in slots) 
        {                                            
            if (slot.transform.childCount > 0)
            {
                Transform child = slot.transform.GetChild(0);
                Text itemName = child.transform.Find("ItemName").GetComponent<Text>();
                Text itemCount = child.transform.Find("ItemCount").GetComponent<Text>();  
                Image imageChildren = child.GetComponent<Image>();
                foreach (Item item in inventory.Items)
                {
                    if (item.Data.Name == itemName.text )
                    {
                        Rarity rararity = colorRarity(imageChildren);
                        item.Quantity[rararity] -= itemCount.text.ParseLargeInteger();
                        int price = item.Data.BasicPrice * ((int)rararity + 1);
                        currency.Coin += price * itemCount.text.ParseLargeInteger();
                        Destroy(child.transform.gameObject);
                        break;
                    }
                    
                }
            }

        }
    }

    private Rarity colorRarity(Image image)
    {
        if (image.color == Color.white)
        {
            return Rarity.Uncommon;
        }else if (image.color == Color.green)
        {
            return Rarity.Rare;
        }else if(image.color == Color.blue)
        {
            return Rarity.Epic;
        }else if (image.color == Color.yellow)
        {
            return Rarity.Legendary;
        }
        return Rarity.Common;
    }

}
