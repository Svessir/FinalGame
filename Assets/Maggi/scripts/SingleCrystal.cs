using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleCrystal : MonoBehaviour, IChargeable, ILightSource {

    public CrystalScript parent;

    public void Charging()
    {
        parent.Charging();
    }

    public void UnCharging()
    {
        parent.UnCharging();
    }

    public float GetIntensity()
    {
        return 0;
    }

    public float GetRadius()
    {
        return 0;
    }

    public Transform GetTransform()
    {
        return this.gameObject.transform;
    }

    //When the crystals Light is shining on something
    private void OnTriggerEnter(Collider other)
    {
        ILightTriggerable monster = other.gameObject.GetComponent(typeof(ILightTriggerable)) as ILightTriggerable;
        if(monster != null)
        {
            monster.DetectingLightsource(this);
        }
       
    }
}
