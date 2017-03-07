using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Facing : MonoBehaviour {
    public Vector3 Test = Vector3.zero;
    public float rotationRate = 180;

    private Vector3 rotationVec = Vector3.zero;
    bool right = true;

	// Update is called once per frame
	void Update ()
    {
        float x = Input.GetAxisRaw("Horizontal");
        if (x > 0.5)
        {
            right = true;
        }
        else if (x < -0.5f)
        {
            right = false;
        }
        if (right)
        {
            if (rotationVec.x < 0) {
                rotationVec.x += rotationRate * Time.deltaTime;
                if (rotationVec.x > 0) {
                    rotationVec.x = 0;
                }
            }
        }
        else
        {
            if (rotationVec.x > -180)
            {
                rotationVec.x -= rotationRate * Time.deltaTime;
                if (rotationVec.x < -180)
                {
                    rotationVec.x = -180;
                }
            }
        }
        transform.rotation = transform.parent.rotation * Quaternion.Euler(rotationVec);// Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(new Vector3(0, 180, 90)), rotationRate * Time.deltaTime);

    }
}
