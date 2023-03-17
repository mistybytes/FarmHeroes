using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class FarmButton : MonoBehaviour
{
    public Button button;

    private void Start()
    {
        button = button.GetComponent<Button>();
        button.onClick.AddListener(LoadScene);
    }

    private void LoadScene()
    {
        Loader.Load(Loader.Scene.Farm);
    }

}
