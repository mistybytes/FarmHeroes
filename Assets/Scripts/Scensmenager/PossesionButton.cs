using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PossesionButton : MonoBehaviour
{

    public Button Button;


    private void Start()
    {
        Button = Button.GetComponent<Button>();
        Button.onClick.AddListener(LoadScean);
    }

    private void LoadScean()
    {
        Loader.Load(Loader.Scene.Possession);
    }
    
    
}
