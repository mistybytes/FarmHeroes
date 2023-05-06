using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stable : MonoBehaviour
{
    public GameObject StableCanva;
    public StableMenager Menager;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            StableCanva.SetActive(true);
            Menager.Invoke();
        }
    }
}
