using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalScript : MonoBehaviour, IChargeable {

    public GameObject crystal;

    public float maxEmission;
    private float minEmission;

    public float intensityGrowthSpeed;
    public float intensityRegressionSpeed;

    public float timeUntilRegression = 0;

    private Material crystalMat;

    private string emissiveName = "_CubemapEmessive";

    private float lastChargeTime;

    //used later for the outward visibility of light to monsters
    //private float maxRadius;
    //private float minRadius;

    // Use this for initialization
    void Start()
    {
        crystalMat = crystal.GetComponent<Renderer>().material;
        minEmission = crystalMat.GetFloat(emissiveName);
    }

    void Update()
    {
        if (Input.GetKey("return"))
        {
            Charge();
        }else
        {
            Uncharge();
        }
    }

    //light source is charging this crystal
    public void Charge()
    {
        float currEmission = crystalMat.GetFloat(emissiveName);
        if(currEmission < maxEmission)
        {
            crystalMat.SetFloat(emissiveName, currEmission + intensityGrowthSpeed * Time.deltaTime);
        }

        lastChargeTime = Time.time;

    }

    private void Uncharge()
    {
        if((lastChargeTime + timeUntilRegression) > Time.time)
        {
            return;
        }

        float currEmission = crystalMat.GetFloat(emissiveName);
        if (currEmission > minEmission)
        {
            crystalMat.SetFloat(emissiveName, currEmission - intensityRegressionSpeed * Time.deltaTime);
        }
    }



    //When the crystals Light is shining on something
    private void OnTriggerEnter(Collider other)
    {

    }
}
