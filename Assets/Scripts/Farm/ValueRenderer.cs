using UnityEngine;

public class ValueRenderer : MonoBehaviour
{
   
    public GameObject Unit, Tens, Value;
    public GameObject[] numbers;
    public PickUpItem Item;
    private int _unit;


    private void Update()
    {
        if (Item.GetValue() != _unit)
        {
            int tens = Item.GetValue() / 10;
            int unit = Item.GetValue() % 10;
            Replace(Unit, numbers[unit], true);
            Replace(Tens, numbers[tens], false);
        }
    }

    void Replace(GameObject oldNumber, GameObject newNumber, bool unit)
    {
        GameObject number =  Instantiate(newNumber, oldNumber.transform.position, oldNumber.transform.rotation, Value.transform);
        _unit = Item.GetValue();
        Destroy(oldNumber);
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
