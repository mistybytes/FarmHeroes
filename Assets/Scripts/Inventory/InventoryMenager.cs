using UnityEngine;

public class InventoryMenager : MonoBehaviour
{
    public static InventoryMenager Instance;
    public Inventory Inventory;
    public Transform ItemContent;
    public GameObject InventoryItem;
    private ListItems Contetn;
    private bool NewItem = false;


    private void Awake()
    {
        Instance = this;
        Contetn = new ListItems(ItemContent, Inventory, InventoryItem);
    }

    public void newItem()
    {
        NewItem = true;
    }

    private void Update()
    {
        if (NewItem)
        {
            Contetn.ListItem();
            NewItem = false;
        }
    }

    public void ListItems()
    {
        Contetn.ListItem();
    }
}
