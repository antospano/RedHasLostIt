using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] Health health;
    [SerializeField] GameObject particle;
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
            }
            else if (gameObject.tag == "Box")
            {
                SoundFXManager.instance.PlaySoundFX(boxDeathSoundClip, transform, 1.0f);
            }
            if (particle)
            {
                Instantiate<GameObject>(particle, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}
