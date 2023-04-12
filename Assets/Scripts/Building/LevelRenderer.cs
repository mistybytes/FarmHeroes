using UnityEngine;

public class LevelRenderer : MonoBehaviour
{
    public GameObject Unit, Tens, Value;
    public GameObject[] numbers;
    public Building Building;
    private int _unit;


    private void Update()
    {
        if (Building.Level != _unit)
        {
            int tens = Building.Level / 10;
            int unit = Building.Level % 10;
            Replace(Unit, numbers[unit], true);
            Replace(Tens, numbers[tens], false);
        }
    }

    void Replace(GameObject oldNumber, GameObject newNumber, bool unit)
    {
        GameObject number = Instantiate(newNumber, oldNumber.transform.position, oldNumber.transform.rotation, Value.transform);
        Destroy(oldNumber);
        _unit = Building.Level;
        if (unit)
        {
            Unit = number;
        }
        else
        {
            Tens = number;
        }
    }
}
