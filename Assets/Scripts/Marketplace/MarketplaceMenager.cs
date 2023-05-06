using UnityEngine;
using UnityEngine.UI;

public class MarketplaceMenager : MonoBehaviour
{
    public static MarketplaceMenager Instance;
    public GameObject Viev,Sale, Buy, InventoryItem;
    public Inventory Inventory;
    public Transform ItemContent;
    public DataController DataController;
    private ListItems Content;
    private bool wosInvoke = false;

    private void OnDisable()
    {
        DataController.SaveStableData();
    }
    private void Start()
    {
        Instance = this;
        Content = new ListItems(ItemContent, Inventory, InventoryItem);
        Button sell = Sale.GetComponent<Button>();
        sell.onClick.AddListener(SellButton);
        Button buy = Buy.GetComponent<Button>();
        buy.onClick.AddListener(BuyButton);
    }

    private void Update()
    {
        if (wosInvoke)
        {
            Content.ListItem();
        }
    }

    void SellButton()
    {
        Sale.SetActive(false);
        Buy.SetActive(true);
        Content.ListItem();
    }

    void BuyButton()
    {
        Content.CleanContent();
        Buy.SetActive(false);
        Sale.SetActive(true);
    }

    public void Invoke()
    {
        wosInvoke = true;
    }

}


