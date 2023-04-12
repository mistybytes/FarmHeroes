using UnityEngine;

public class ExpBarBuilding : MonoBehaviour
{
    public GameObject ExpBar;
    public Building building;
    private float _unit;

    private float minPosisionX = -1.9f;
    private float minScaleX = 0.1f;
    private float maxPosisionX = 0.13f;
    private float maxScaleX = 3.95f;



     void Start()
     {
        _unit = building.Exp;
        ExpBarUpdate();
     }

    private void Update()
    {
        if (_unit != building.Exp)
        {
            ExpBarUpdate();
        }
    }

    void ExpBarUpdate()
    {
        float expProcent = ((float)building.Exp / (float)building.MaxExp);
        float ragePosision =Mathf.Abs(maxPosisionX - minPosisionX);
        float rageScale =Mathf.Abs(maxScaleX - minScaleX);
        float valuePosition =minPosisionX + (ragePosision * expProcent) ;
        float valueScale =minScaleX + (rageScale * expProcent);
        ExpBar.transform.localPosition = new Vector3(valuePosition, ExpBar.transform.localPosition.y, ExpBar.transform.localPosition.z);
        ExpBar.transform.localScale = new Vector3(valueScale, ExpBar.transform.localScale.y, ExpBar.transform.localScale.z);
    }
  

 
}
