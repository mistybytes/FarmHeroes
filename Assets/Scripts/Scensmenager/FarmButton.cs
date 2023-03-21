using UnityEngine;

public class FarmButton : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Loader.Load(Loader.Scene.Farm);
        }
    }

}
