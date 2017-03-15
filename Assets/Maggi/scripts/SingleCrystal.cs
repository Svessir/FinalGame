﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleCrystal : MonoBehaviour, IChargeable, ILightSource
{

    public CrystalScript parent;

    public Light light;

    public SphereCollider lightCollider;

    private List<GameObject> visibleStuff;

    public void Start()
    {
        visibleStuff = new List<GameObject>();
    }

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
        return lightCollider.radius * gameObject.transform.localScale.x;
    }

    public Transform GetTransform()
    {
        return this.gameObject.transform;
    }


    ////When the crystals Light is shining on something
    //private void OnTriggerEnter(Collider other)
    //{
    //    ILightTriggerable monster = other.gameObject.GetComponent(typeof(ILightTriggerable)) as ILightTriggerable;
    //    if (monster != null)
    //    {
    //        if (visibleStuff.Contains(other.gameObject))
    //        {
    //            return;
    //        }
    //        RaycastHit hitInfo = new RaycastHit();
    //        Vector3 lightToMon = other.gameObject.transform.position - transform.position;
    //        Ray ray = new Ray(transform.position, lightToMon);
    //        bool hit = Physics.Raycast(ray, out hitInfo, GetRadius() + 1);

    //        visibleStuff.Add(other.gameObject);
    //        monster.DetectingLightsource(this);
    //    }

    //}

    private void OnTriggerStay(Collider other)
    {
        ILightTriggerable monster = other.gameObject.GetComponent(typeof(ILightTriggerable)) as ILightTriggerable;
        if (monster != null)
        {
            RaycastHit hitInfo = new RaycastHit();
            LayerMask mask = ~((1 << 13) | (1 << 8));
            Vector3 lightToMon = other.gameObject.transform.position - transform.position;
            Ray ray = new Ray(transform.position, lightToMon);

            bool hit = Physics.Raycast(ray, out hitInfo, GetRadius(), mask);

            if (hit)
            {
                if (visibleStuff.Contains(other.gameObject))
                {
                    monster.UndetectLightsource(this);
                    visibleStuff.Remove(this.gameObject);
                    return;
                }
            }

            if (visibleStuff.Contains(other.gameObject))
            {
                return;
            }

            monster.DetectingLightsource(this);
            visibleStuff.Add(other.gameObject);

        }

    }


    //When the crystals Light is shining on something
    private void OnTriggerExit(Collider other)
    {
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


}