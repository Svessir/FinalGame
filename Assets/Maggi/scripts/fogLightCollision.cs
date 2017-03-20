using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fogLightCollision : MonoBehaviour, ILightSource
{
    public float detectionRange;
    private List<GameObject> visibleStuff;
   // public LayerMask mask;

    public void Start()
    {
        detectionRange = this.transform.localScale.z;
        visibleStuff = new List<GameObject>();
    }

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

    //private void OnTriggerEnter(Collider other)
    //{
    //    IChargeable chargeable = other.gameObject.GetComponent(typeof(IChargeable)) as IChargeable;
    //    if (chargeable != null)
    //    {
    //        chargeable.Charging();
    //    }


    //}

    private void OnTriggerExit(Collider other)
    {
        //IChargeable chargeable = other.gameObject.GetComponent(typeof(IChargeable)) as IChargeable;
        //if (chargeable != null)
        //{
        //    chargeable.UnCharging();
        //}

        ILightTriggerable monster = other.gameObject.GetComponent(typeof(ILightTriggerable)) as ILightTriggerable;
        if (monster != null)
        {
            if (visibleStuff.Contains(other.gameObject))
            {
                visibleStuff.Remove(other.gameObject);
                monster.UndetectLightsource(this);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        ILightTriggerable monster = other.gameObject.GetComponent(typeof(ILightTriggerable)) as ILightTriggerable;
        if (monster != null)
        {
            //check layer

            LayerMask mask;

            int layer = other.gameObject.layer;

            //if enemy
            //if (layer == 8)
            //{
                mask = ~((1 << 13) | (1 << 8) | (1 << 11));
           // }
     //       else
         //   {//light layer is number 13

       //     }

            ///notes:
            ///use ilighttriggerable for both enemies and crystals
            ///enemies and crystals need different masks

            RaycastHit hitInfo = new RaycastHit();

            Vector3 lightToMon = other.gameObject.transform.position - transform.position;
            Ray ray = new Ray(transform.position, lightToMon);

//            float rayLength = Mathf.Min(lightToMon.magnitude, GetRadius());

            bool hit = Physics.Raycast(ray, out hitInfo, lightToMon.magnitude, mask);

            if (hit)
            {
                if (visibleStuff.Contains(other.gameObject))
                {
                    monster.UndetectLightsource(this);
                    visibleStuff.Remove(this.gameObject);
                }
                return;
            }

            if (visibleStuff.Contains(other.gameObject))
            {
                return;
            }

            monster.DetectingLightsource(this);
            visibleStuff.Add(other.gameObject);

        }
    }
}
