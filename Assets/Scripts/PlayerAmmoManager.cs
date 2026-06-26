using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAmmoManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private DisplayValue displayAmmo;
    [SerializeField] private DisplayValue displayWeaponAmmo;

    private void Update()
    {
        if (GameStateManager.instance.isPaused)
        {
            return;
        }
        if (player.ammo.value < 0)
        {
            player.ammo.SetAmmo(0);
        }

        displayAmmo.value = player.ammo.value;
        displayWeaponAmmo.value = player.GetWeapon().currentAmmo;
    }
}
