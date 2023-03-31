using UnityEngine;

[CreateAssetMenu(fileName = "New Building", menuName = "Building/New Building")]
public class Building: ScriptableObject
{
    public int Id;
    public string Name;
    public int Level;
}
