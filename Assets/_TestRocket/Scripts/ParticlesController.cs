using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesController : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] firePS;
    private ParticleSystem[] myFirePS;
    void Start()
    {
        myFirePS = new ParticleSystem[firePS.Length];

        for (int i = 0; i < firePS.Length; i++)
        {
            myFirePS[i] = firePS[i];
        }

        ChangeRate(0);
    }

    public void ChangeRate(float newRate)
    {
        for (int i = 0; i < myFirePS.Length; i++)
        {
            var emission = myFirePS[i].emission;
            emission.rateOverTime = newRate;
        }
    }
}
