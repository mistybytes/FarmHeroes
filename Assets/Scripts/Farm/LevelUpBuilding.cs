using UnityEngine;

public class LevelUpBuilding : MonoBehaviour
{
    public Building Building;
    public Currency currency;
    public int coinPerSecond;


    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player" && Building.Level <= 100)
        {
            if (currency.Coin >= coinPerSecond)
            {
                currency.Coin -= coinPerSecond;
                Building.Exp += coinPerSecond;
                IsLevelUP();
            }
        }
    }

    private void IsLevelUP()
    {
        if(Building.MaxExp < Building.Exp)
        {
            Building.Level += 1;
            Building.Exp -= Building.MaxExp;
        }
    }


}
