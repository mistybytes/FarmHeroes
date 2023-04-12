using UnityEngine;


public class Marketplace : MonoBehaviour
{
    public GameObject View;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            View.SetActive(true);
            MarketplaceMenager.Instance.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            View.SetActive(false);
        }
    }
    
}
