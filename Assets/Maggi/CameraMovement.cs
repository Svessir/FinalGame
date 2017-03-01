using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public Transform sub;

    private void LateUpdate()
    {
        Vector3 newPos;
        newPos.x = sub.position.x;
        newPos.y = sub.position.y;
        newPos.z = this.transform.position.z;
        this.transform.position = newPos;

    }
}
