using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndEffect : MonoBehaviour
{
    private ParticleSystem particle;
    
    [SerializeField]
    private bool isChild;
    // Start is called before the first frame update
    void Start()
    {
        particle = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(particle.isStopped)
        {
            if (isChild)
            {
                Destroy(gameObject.transform.parent.gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
