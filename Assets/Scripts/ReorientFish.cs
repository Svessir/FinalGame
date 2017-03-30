using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReorientFish : MonoBehaviour {
    public float rotRate = 90;
    float angle = 0;
	// Update is called once per frame
	void Update () {
        if (transform.forward.x < 0) {
            if (angle < 180) {
                angle += rotRate * Time.deltaTime;
                if (angle > 180) {
                    angle = 180;
                }
            }
        } else
        {
            if (angle > 0)
            {
                angle -= rotRate * Time.deltaTime;
                if (angle < 0)
                {
                    angle = 0;
                }
            }
        }
        transform.rotation = transform.parent.rotation* Quaternion.Euler(new Vector3(0, 90, angle));

    }
}
