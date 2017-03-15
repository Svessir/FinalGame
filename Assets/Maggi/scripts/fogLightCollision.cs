using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fogLightCollision : MonoBehaviour, ILightSource
{
    public float detectionRange;

    public float GetIntensity()
    {
        return 1;
    }

    public float GetRadius()
    {
        return detectionRange;
    }

    public Transform GetTransform()
    {
        return this.transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        IChargeable chargeable = other.gameObject.GetComponent(typeof(IChargeable)) as IChargeable;
        if (chargeable != null)
        {
            chargeable.Charging();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        IChargeable chargeable = other.gameObject.GetComponent(typeof(IChargeable)) as IChargeable;
        if (chargeable != null)
        {
            chargeable.UnCharging();
        }
    }




}
