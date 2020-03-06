using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveParticle : MonoBehaviour
{
    public float speed;
    public ParticleSystem ps;

    private void Awake()
    {
        ps = GetComponent<ParticleSystem>();
        speed = 1f;
    }
    private void FixedUpdate()
    {
        speed += Time.deltaTime;
        var main = ps.main;
        main.startSpeed = speed * 50f;
        main.simulationSpeed = speed * 3f;
    }
}
