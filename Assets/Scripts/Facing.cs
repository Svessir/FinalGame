using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Facing : MonoBehaviour {
    public Vector3 Test = Vector3.zero;
    public float rotationRate = 180;

    private Vector3 rotationVec = Vector3.zero;
    bool right = true;

	void Start() {
		rotationVec = transform.rotation.eulerAngles;
	}
	// Update is called once per frame
	void Update ()
    {
        float y = Input.GetAxisRaw("Horizontal");
        if (y > 0.5)
        {
            right = true;
        }
        else if (y < -0.5f)
        {
            right = false;
        }
        if (right)
        {
            if (rotationVec.y < 0) {
                rotationVec.y += rotationRate * Time.deltaTime;
                if (rotationVec.y > 0) {
                    rotationVec.y = 0;
                }
            }
        }
        else
        {
            if (rotationVec.y > -180)
            {
                rotationVec.y -= rotationRate * Time.deltaTime;
                if (rotationVec.y < -180)
                {
                    rotationVec.y = -180;
                }
            }
        }
        transform.rotation = transform.parent.rotation * Quaternion.Euler(rotationVec);// Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(new Vector3(0, 180, 90)), rotationRate * Time.deltaTime);

    }
}
