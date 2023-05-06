using UnityEngine;

public class StableMenager : MonoBehaviour
{
    public static StableMenager Instance;
    public Inventory inventory;
    public GameObject inventoryItem;
    public Transform ItemContent;
    public FarmSO Farm;
    private ListItems Content;

    private bool wosInvoke = false;

    private void Start()
    {
        Instance = this;
        Content = new ListItems(ItemContent, inventory, inventoryItem);
    }

    private void Update()
    {
        if (wosInvoke)
        {
            Content.ListItem();
        }
    }

    public void Invoke()
    {
        wosInvoke = true;
    }
}
