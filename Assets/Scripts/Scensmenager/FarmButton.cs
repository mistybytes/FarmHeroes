using UnityEngine;

public class FarmButton : MonoBehaviour
{
    public DataController dataController;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            dataController.SaveInventoryData();
            Loader.Load(Loader.Scene.Farm);
        }
    }

}
