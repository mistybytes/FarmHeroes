using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]
public class ItemSO : ScriptableObject
{
    public string Name;
    public Sprite Icon;
    public int BasicPrice;
}
