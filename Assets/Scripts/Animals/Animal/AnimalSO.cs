using UnityEngine;

[CreateAssetMenu(fileName = "New Animal", menuName = "Animal/Create New Animal")]
public class AnimalSO : ScriptableObject
{
    public string Name;
    public int BasicHealth;
    public int BasicSpeed;
    public int BasicPower;
    public int BasicFocus;
    public int Energy;
    public int Star;
    public int Level;
    public Sprite Icon;
    public GameObject Model;
}
