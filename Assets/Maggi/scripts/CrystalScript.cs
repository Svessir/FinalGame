﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalScript : MonoBehaviour{

    public List<GameObject> veins;

    public List<SingleCrystal> crystals;

    private AudioSource audio;

    public List<AudioSource> audios;

    public float minBrightness;
    public float maxBrightness;

    public float intensityGrowthSpeed;
    public float intensityRegressionSpeed;

    //time from charging crystal stopped until it starts regressing
    public float timeUntilRegression;

    //% of how much emission changes relative to lightIntensity
    public float emissionGrowthFactor;

    public float RadiusGrowthFactor;
    //private float currentRadius = 0;

    private List<Material> crystalMats;

    //put name of emissive value of veins here
    private string emissiveName = "_CubemapEmessive";


    private float lastChargeTime;

    private float currentBrightness = 0;

    private bool isCharging = false;

    private float intensity = 0;

    private bool isLitFam = false;

    private float initialVolume;

    

    //used later for the outward visibility of light to monsters
    //private float maxRadius;
    //private float minRadius;

    // Use this for initialization
    void Start()
    {
        crystalMats = new List<Material>();
        if (veins.Count > 0)
        {
            crystals.Clear();
        }
        if (veins.Count != 0)
        {
            foreach (var vein in veins)
            {
                crystalMats.Add(vein.GetComponentInChildren<Renderer>().material);
                crystals.Add(vein.GetComponent<SingleCrystal>());
            }
            veins.Clear();
        }
        
        foreach(var c in crystals)
        {
            c.parent = this;
        }

		if (audios.Count > 0) {
			int megas = Random.Range(0, audios.Count);

			audio = audios[megas];

			initialVolume = audio.volume;
		}
    }

    //maybe change this so that dark things that have low maxBrightness are not as bright as others
    public float GetIntensity()
    {
        return (currentBrightness- minBrightness)/(maxBrightness - minBrightness);
    }

    public void Charging()
    {
        isCharging = true;
    }

    public void UnCharging()
    {
        isCharging = false;
    }

    private void Update()
    {
        if (isCharging)
        {
            isLitFam = true;
            Charge();
        }else
        {
            Uncharge();
        }
        if(currentBrightness <= minBrightness + 0.1)
        {
            isLitFam = false;
        }
        HandleSound();

    }

    private void HandleSound()
    {
		if (audio == null)
			return;
		
        audio.volume = initialVolume * GetIntensity();
        if (isLitFam)
        {
            if (audio.isPlaying)
            {
                return;
            }
            audio.Play();
        }
        else
        {
            if (!audio.isPlaying)
            {
                return;
            }
            audio.Stop();
        }

        
    }

    //light source is charging this crystal
    public void Charge()
    {
        float lightDelta = intensityGrowthSpeed * Time.deltaTime;

        if (currentBrightness + lightDelta < maxBrightness)
        {
            currentBrightness += lightDelta;

            foreach (var mat in crystalMats)
            {
                mat.SetFloat(emissiveName, currentBrightness * emissionGrowthFactor);
            }

            foreach (var c in crystals)
            {
                c.lightCollider.radius += RadiusGrowthFactor * Time.deltaTime;
                c.light.intensity = currentBrightness;
            }
        }
        lastChargeTime = Time.time;
    }

    private void Uncharge()
    {
        float lightDelta = intensityRegressionSpeed * Time.deltaTime;

        if(((lastChargeTime + timeUntilRegression) > Time.time) || ((currentBrightness - lightDelta) < minBrightness))
        {
            return;
        }

        currentBrightness -= lightDelta;

        foreach (var mat in crystalMats)
        {
            mat.SetFloat(emissiveName, currentBrightness  * emissionGrowthFactor);
        }

        foreach (var c in crystals)
        {
            c.lightCollider.radius -= RadiusGrowthFactor * Time.deltaTime;
            c.light.intensity = currentBrightness;
        }
    }
}
