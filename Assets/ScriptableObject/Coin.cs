using UnityEngine;
using UnityEngine.UI;


public class Coin : MonoBehaviour
{
    public Text Value;
    public Currency Currency;
    private int _unit;

    void Start()
    {
        _unit = Currency.Coin;
        Value.text = Currency.Coin.ToString();
    }

    void Update()
    {
        if (_unit != Currency.Coin)
        {
            Value.text = Currency.Coin.ToString();
            _unit = Currency.Coin;
        }

    }
}
