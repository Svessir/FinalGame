using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuctionField : MonoBehaviour {

    public float Strength;
    //to determine when to stop seeking center and start falling down
    public float distThreshold;
    float radius;
    private void Start() {
        radius = transform.localScale.x/2 +3;
    }
    
    void OnTriggerStay(Collider other)
    {
        if (other.attachedRigidbody)
        {
            if (pointToLine(other.transform.position) < distThreshold)
            {
                other.attachedRigidbody.AddForce(-transform.up.normalized * 1 * Strength * Time.deltaTime);
            }
            else
            {
                Vector3 dir = transform.position - other.transform.position;
                float dist = dir.magnitude / radius;
                dist = 1 - dist;
                other.attachedRigidbody.AddForce(dir.normalized * dist * Strength * Time.deltaTime);

            }
        }
    }

    float pointToLine(Vector3 point) {
        Vector3 dif = point - transform.position;
        Vector3 vec = dif - Vector3.Dot(dif, transform.up) * transform.up;
        return vec.magnitude;
    }
}
