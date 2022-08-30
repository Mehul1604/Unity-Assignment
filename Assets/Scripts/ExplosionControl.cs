using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionControl : MonoBehaviour
{
    // Start is called before the first frame update
    private ParticleSystem ps;
    private GameObject particle_object;
    private bool visible;
    void Start()
    {
        particle_object = transform.GetChild(0).gameObject;
        ps = particle_object.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(ps.time);
        if(visible)
        {
            if(ps.time > 0)
            {
                transform.localScale = new Vector3(0 , 0 , 0);
            }
        }
    }

    void OnBecameVisible()
    {
        visible = true;
        ps.Play();
    }

    void OnBecameInvisible()
    {
        visible = false;
        transform.localScale = new Vector3(1 , 1 , 1);
        ps.Stop();
    }
}
