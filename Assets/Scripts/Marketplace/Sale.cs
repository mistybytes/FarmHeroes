using Palmmedia.ReportGenerator.Core.Common;
using UnityEngine;
using UnityEngine.UI;

public class Sale : MonoBehaviour
{
    public GameObject[] slots = new GameObject[3];

    public GameObject SaleButton;

    public Currency currency;

    public Coin coin;


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
                var child = slot.transform.GetChild(0);
                Text itemName = child.transform.Find("ItemName").GetComponent<Text>();
                Text itemCount = child.transform.Find("ItemCount").GetComponent<Text>();          
                foreach (Item item in MarketplaceMenager.Instance.Inventory.Items)
                {
                    if (item.itemName == itemName.text)
                    {
                        item.value -= itemCount.text.ParseLargeInteger();
                        currency.Coin += item.price * itemCount.text.ParseLargeInteger();
                        Destroy(child.transform.gameObject);
                        break;
                    }
                    
                }
            }

        }
    }
}
