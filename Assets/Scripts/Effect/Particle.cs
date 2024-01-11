using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    public GameObject GOEFFECT;
    void InitParticle()
    {
        GOEFFECT.SetActive(true);
    }
    void DestroyParticle()
    {
        GOEFFECT.SetActive(false);
    }
}
