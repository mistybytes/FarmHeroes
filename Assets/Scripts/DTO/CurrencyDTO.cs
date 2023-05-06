using System;

[Serializable]
public class CurrencyDTO
{
    public int Coin;
    public int Diamond;

    public CurrencyDTO (Currency currency)
    {
        Coin = currency.Coin;
        Diamond = currency.Diamond;
    }
}



