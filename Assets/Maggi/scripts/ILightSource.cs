using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILightSource {

    float GetIntensity();
    float GetRadius();
    Transform GetTransform();
}
