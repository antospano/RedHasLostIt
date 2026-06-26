using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : Pickup
{
    [SerializeField] private int _value;
    [SerializeField] private AudioClip audioClip;
    private Ammo ammo;

    private void Start()
    {
        base.value = _value;
    }

    public override void PickupBehavior()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SoundFXManager.instance.PlaySoundFX(audioClip, transform, 1.0f);
            ammo = collision.gameObject.GetComponent<Player>().GetWeapon().gameObject.GetComponent<Ammo>();
            ammo.SetAmmo(ammo.value + base.value);
            base.pickedUp = true;
            SoundFXManager.instance.PlaySoundFX(audioClip, transform, 1.0f);
        }
    }
}
