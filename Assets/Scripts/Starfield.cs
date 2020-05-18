using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starfield : MonoBehaviour
{
    [SerializeField]
    List<ParticleSystem> systems = new List<ParticleSystem>();

    List<float> initialSpeeds = new List<float>();

    [SerializeField]
    float relativeSpeed = 1.0f;

    public float RelativeSpeed
    {
        get
        {
            return relativeSpeed;
        }
        set
        {
            relativeSpeed = value;
            SetValues();
        }
    }

    private void Awake()
    {
        foreach (var system in systems)
        {
            initialSpeeds.Add(system.main.simulationSpeed);
        }
    }

    void SetValues()
    {
        for (int i = 0; i < systems.Count; i++)
        {
            var main = systems[i].main;
            main.simulationSpeed = initialSpeeds[i] * relativeSpeed;
        }
    }

    private void Update()
    {
        SetValues();
    }
}
