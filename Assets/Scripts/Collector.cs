using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class Collector : MonoBehaviour
{
    public Text Text;
    private int value;

    void Start()
    {
        value = 0;
        StartCoroutine(EnableTimedBonus());
    }

    private void OnMouseDown()
    {
        value = 0;
    }

    IEnumerator EnableTimedBonus()
    {
        Debug.Log("Co tu siê wyprawia");
        while (true)
        {
            yield return new WaitForSeconds(1);
            if (value < 60)
            {
                value++;
            }
        }
    }


    void Update()
    {

        Text.text = value.ToString();
    }
}
