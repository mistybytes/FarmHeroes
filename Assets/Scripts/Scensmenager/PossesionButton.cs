using UnityEngine;

public class PossesionButton : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Loader.Load(Loader.Scene.Possesion);
        }
    
    }
}
