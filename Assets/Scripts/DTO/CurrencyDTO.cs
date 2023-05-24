using System;

[Serializable]
public class CurrencyDTO
{
    public int Coin;
    public int Diamond;

    public CurrencyDTO()
    {
        Coin = 0;
        Diamond = 0;
    }

    public CurrencyDTO (Currency currency)
    {
        Coin = currency.Coin;
        Diamond = currency.Diamond;
    }
}



