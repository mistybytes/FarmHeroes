using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirldDoor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Loader.Load(Loader.Scene.Field);
        }
    }
}
