using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : Pickup
{
    [SerializeField] private int randMin;
    [SerializeField] private int randMax;
    [SerializeField] private AudioClip audioClip;
    private Health health;

    private void Start()
    {
        base.value = Random.Range(randMin, randMax);
    }

    public override void PickupBehavior()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            health = Check.ComponentExists<Health>(collision.gameObject);
            if (health.value < collision.gameObject.GetComponent<PlayerHealthManager>().GetMaxHealth())
            {
                health.SetHealth(health.value + base.value);
                base.pickedUp = true;
                SoundFXManager.instance.PlaySoundFX(audioClip, transform, 1.0f);
            }
            
        }
    }
}
