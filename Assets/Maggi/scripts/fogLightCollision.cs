using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fogLightCollision : MonoBehaviour {


    private void OnTriggerEnter(Collider other)
    {
        IChargeable chargeable = other.gameObject.GetComponent(typeof(IChargeable)) as IChargeable;
        if(chargeable != null)
        {
            chargeable.Charging();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        IChargeable chargeable = other.gameObject.GetComponent(typeof(IChargeable)) as IChargeable;
        if(chargeable != null)
        {
            chargeable.UnCharging();
        }
    }
}
