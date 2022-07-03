using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAmmoManager : MonoBehaviour
{
    [SerializeField] private Ammo ammo;
    [SerializeField] private Weapon weapon;
    [SerializeField] private DisplayValue displayAmmo;
    [SerializeField] private DisplayValue displayWeaponAmmo;

    private void Update()
    {
        if (ammo.value < 0)
        {
            ammo.SetAmmo(0);
        }

        displayAmmo.value = ammo.value;
        displayWeaponAmmo.value = weapon.currentAmmo;
    }
}
