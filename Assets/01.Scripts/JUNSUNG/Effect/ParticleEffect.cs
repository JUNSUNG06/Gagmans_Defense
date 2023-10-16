using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class ParticleEffect : Effect
{
    ParticleSystem particle;
    private void Awake()
    {
        particle = GetComponent<ParticleSystem>();
        wait = new WaitUntil(() => particle.isPaused);
    }

    public override void Init()
    {
        StartCoroutine(Push());
    }

    public override void Flip(bool value)
    {
        Vector3 flip = particle.GetComponent<ParticleSystemRenderer>().flip;

        if (value)
            particle.GetComponent<ParticleSystemRenderer>().flip = new Vector3(1, flip.y, flip.z);
        else
            particle.GetComponent<ParticleSystemRenderer>().flip = new Vector3(0, flip.y, flip.z);
    }
}
