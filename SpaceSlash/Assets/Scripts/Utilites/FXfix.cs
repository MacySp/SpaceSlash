using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXfix : MonoBehaviour
{
    public float scale = 0.3f;
    public bool changecolour = false;
    public Color yourColor;

    // Start is called before the first frame update
    void Start()
    {
        ParticleSystem.MainModule settings = GetComponent<ParticleSystem>().main;

        var psys = GetComponentsInChildren<ParticleSystem>();
        foreach (var ps in psys)
        {
            var main = ps.main;
            main.scalingMode = ParticleSystemScalingMode.Local;
            ps.transform.localScale = new Vector3(scale, scale, scale);
        }
        if (changecolour)
        {
            settings.startColor = new ParticleSystem.MinMaxGradient(yourColor);
        }

    }
}