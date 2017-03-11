using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalScript : MonoBehaviour, IChargeable {

    public Light light;
    public GameObject crystal;

    private float minLightIntensity;
    public float maxLightIntensity;

    //public float maxMatEmission;

    public float lightIntensityGrowthSpeed;
    public float lightIntensityRegressionSpeed;

    private bool charging = false;


    //private Material crystalMat;


    //private float minMatEmission;

    //used later for the outward visibility of light to monsters
    //private float maxRadius;
    //private float minRadius;

    // Use this for initialization
    void Start()
    {
        //Renderer crystalRenderer = crystal.GetComponent<Renderer>();
        //crystalMat = crystalRenderer.material;
        minLightIntensity = light.intensity;
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
        if(light.intensity < maxLightIntensity)
        {
            light.intensity += lightIntensityGrowthSpeed * Time.deltaTime;
        }
    }

    private void Uncharge()
    {
        if(light.intensity > minLightIntensity)
        {
            light.intensity -= lightIntensityGrowthSpeed * Time.deltaTime;
        }
    }



    //When the crystals Light is shining on something
    private void OnTriggerEnter(Collider other)
    {

    }
}
