using UnityEngine;

[CreateAssetMenu(fileName = "New Building", menuName = "Building/New Building")]
public class Building: ScriptableObject
{
    public int Id;
    public string Name;
    public int Level =1;
    public int Exp = 0;
    public int MaxExp => Level * 500;

}
