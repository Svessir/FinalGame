using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fogLightCollision : MonoBehaviour {


    private void OnTriggerStay(Collider other)
    {
        IChargeable chargeable = other.gameObject.GetComponent(typeof(IChargeable)) as IChargeable;
        if(chargeable != null)
        {
            chargeable.Charge();
        }
    }
}
