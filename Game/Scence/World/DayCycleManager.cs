using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycleManager : MonoBehaviour
{
    [Range (0,1)]
    public float TimeofDay;
    public float DayDuration = 30f;

    public AnimationCurve SunCurve;
    //public AnimationCurve MoonCurve;
    // public AnimationCurve SkyboxCurve;

    //public Material DaySkybox;
    // public Material NightSkybox;

    public Light Sun;
    //public Light Moon;

    private float sunIntensity;
    //private float moonIntensity;

    void Start()
    {
        sunIntensity = Sun.intensity;
        // moonIntensity = Moon.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        TimeofDay += Time.deltaTime / DayDuration;
        if (TimeofDay >= 1) TimeofDay -= 1;

        //RenderSettings.skybox.Lerp(NightSkybox, DaySkybox, SkyboxCurve.Evaluate(TimeofDay));
        // DynamicGI.UpdateEnvironment();

        Sun.transform.localRotation = Quaternion.Euler(TimeofDay * 360f, 180, 0);
        //Moon.transform.localRotation = Quaternion.Euler(TimeofDay * 360f + 180f, 180, 0);

        Sun.intensity = sunIntensity * SunCurve.Evaluate(TimeofDay);
        //Moon.intensity = moonIntensity * MoonCurve.Evaluate(TimeofDay);
    }
}
