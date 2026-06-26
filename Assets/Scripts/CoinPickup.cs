using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : Pickup
{
    [SerializeField] private AudioClip audioClip;
    private Points points;

    private void Start()
    {
        base.value = 10; // Set a fixed value for the coin pickup
    }

    public override void PickupBehavior()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            points = Check.ComponentExists<Points>(collision.gameObject);
            points.SetPoints(points.value + base.value);
            SoundFXManager.instance.PlaySoundFX(audioClip, transform, 1.0f);
            base.pickedUp = true;
        }
    }
}
