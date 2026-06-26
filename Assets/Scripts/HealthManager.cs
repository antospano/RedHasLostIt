using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] Health health;
    [SerializeField] GameObject particle;
    [SerializeField] GameObject coinPickup;
    [SerializeField] AudioClip piggyDeathSoundClip;
    [SerializeField] AudioClip boxDeathSoundClip;

    private void Update()
    {
        if (GameStateManager.instance.isPaused)
        {
            return;
        }
        if (health.value <= 0)
        {
            if (gameObject.tag == "Piggy")
            {
                SoundFXManager.instance.PlaySoundFX(piggyDeathSoundClip, transform, 1.0f);
                Instantiate(coinPickup, transform.position, Quaternion.identity);
            }
            else if (gameObject.tag == "Box")
            {
                SoundFXManager.instance.PlaySoundFX(boxDeathSoundClip, transform, 1.0f);
            }
            if (particle)
            {
                Instantiate(particle, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}
