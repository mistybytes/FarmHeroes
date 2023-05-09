using UnityEngine;

public class PossesionButton : MonoBehaviour
{
    public DataController controller;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            controller.SaveInventoryData();
            Loader.Load(Loader.Scene.Possesion);
        }
    
    }
}
