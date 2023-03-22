using System.Collections;
using UnityEngine;

public class ValueRenderer : MonoBehaviour
{
    public Item item;
   
    public GameObject Unit, Tens, Value;
    public GameObject[] numbers;

    private int _unit;


    private void Start()
    {
        _unit = item.value;
        StartCoroutine(EnableTimedBonus());
    }

    private void Update()
    {
        if (item.value != _unit)
        {
            int tens = item.value / 10;
            int unit = item.value % 10;
            Replace(Unit, numbers[unit], true);
            Replace(Tens, numbers[tens], false);
        }
    }

    void Replace(GameObject oldNumber, GameObject newNumber, bool unit)
    {
        GameObject number =  Instantiate(newNumber, oldNumber.transform.position, oldNumber.transform.rotation, Value.transform);
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

    IEnumerator EnableTimedBonus()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            if (item.value < 60)
            {
                item.value += 1;
            }
        }
    }
}
