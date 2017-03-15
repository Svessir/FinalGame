using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILightTriggerable
{
    void DetectingLightsource(ILightSource obj);
    void UndetectLightsource(ILightSource obj);
}
