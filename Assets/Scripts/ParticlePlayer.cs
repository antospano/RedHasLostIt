using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePlayer : MonoBehaviour
{
    [SerializeField] private ParticleSystem particles;

    private void Start()
    {
        particles.transform.position = transform.position + new Vector3(0, 0, -1);
    }

    private void Update()
    {
        if (particles.isStopped)
        {
            Destroy(gameObject);
        }
    }
}
