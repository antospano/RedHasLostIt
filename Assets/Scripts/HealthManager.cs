using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] Health health;
    [SerializeField] GameObject particle;

    private void Update()
    {
        if (GameStateManager.instance.isPaused)
        {
            return;
        }
        if (health.value <= 0)
        {
            if (particle)
            {
                Instantiate<GameObject>(particle, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}
