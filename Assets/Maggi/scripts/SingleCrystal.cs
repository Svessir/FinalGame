using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleCrystal : MonoBehaviour, IChargeable, ILightSource {

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
    //    if(monster != null)
    //    {
    //        monster.DetectingLightsource(this);
    //    }

    //}

    private void OnTriggerStay(Collider other)
    {
        ILightTriggerable monster = other.gameObject.GetComponent(typeof(ILightTriggerable)) as ILightTriggerable;
        if (monster != null)
        {
            RaycastHit hitInfo = new RaycastHit();
            Vector3 lightToMon = other.gameObject.transform.position - transform.position;
            Ray ray = new Ray(transform.position, lightToMon);
            bool hit = Physics.Raycast(ray, out hitInfo, GetRadius() + 1);

            if (visibleStuff.Contains(hitInfo.collider.gameObject))
            {
                if (!hit)
                {

                    monster.UndetectLightsource(this);
                }
            }
            else
            {
                if (hit)
                {
                    monster.DetectingLightsource(this);
                }
            }

        }

    }
}

    ////When the crystals Light is shining on something
    //private void OnTriggerExit(Collider other)
    //{
    //    ILightTriggerable monster = other.gameObject.GetComponent(typeof(ILightTriggerable)) as ILightTriggerable;
    //    if (monster != null)
    //    {
    //        monster.UndetectLightsource(this);
    //    }

    //}

