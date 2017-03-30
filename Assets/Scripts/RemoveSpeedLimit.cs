using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveSpeedLimit : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            var mov = other.gameObject.transform.parent.GetComponent<Movement>();
            if (mov != null) {
                mov.maxSpeed = 999;
                mov.acceleration = 0;
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            var mov = other.gameObject.transform.parent.GetComponent<Movement>();
            if (mov != null)
            {
                mov.maxSpeed = 10;
                mov.acceleration = 10;
            }
        }
    }

}
