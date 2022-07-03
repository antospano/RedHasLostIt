using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : Pickup
{
    [SerializeField] private int _value;
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
            ammo = collision.gameObject.GetComponent<Player>().GetWeapon().gameObject.GetComponent<Ammo>();
            ammo.SetAmmo(ammo.value + base.value);
            base.pickedUp = true;
        }
    }
}
