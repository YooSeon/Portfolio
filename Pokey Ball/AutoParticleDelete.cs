using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoParticleDelete : MonoBehaviour
{
    private ParticleSystem ps;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        Destroy(this.gameObject, 1f);
    }
}
