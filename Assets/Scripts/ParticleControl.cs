using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleControl : MonoBehaviour
{

    // Start is called before the first frame update
    private ParticleSystem ps;
    private GameObject particle_object;
    void Start()
    {
        particle_object = transform.GetChild(0).gameObject;
        ps = particle_object.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(ps.isPaused);
    }

    void OnBecameVisible()
    {
        ps.Play();
    }

    void OnBecameInvisible()
    {
        ps.Stop();
    }
}
