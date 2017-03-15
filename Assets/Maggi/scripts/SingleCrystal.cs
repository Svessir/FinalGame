using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleCrystal : MonoBehaviour, IChargeable, ILightSource {

    public CrystalScript parent;

    public Light light;

    public SphereCollider lightCollider;

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
        return parent.GetIntensity();
    }

    public float GetRadius()
    {
        return lightCollider.radius / gameObject.transform.localScale.x;
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

    //When the crystals Light is shining on something
    private void OnTriggerExit(Collider other)
    {
        ILightTriggerable monster = other.gameObject.GetComponent(typeof(ILightTriggerable)) as ILightTriggerable;
        if (monster != null)
        {
            monster.UndetectLightsource(this);
        }

    }
}
