using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void WeaponDelegate();

public class WeaponEvents : MonoBehaviour
{
    //various variables used for the events
    [SerializeField] private Weapon weapon;
    [SerializeField] private FadeOut fade;
    [SerializeField] private GameObject shotTexture;
    private GameObject shot;
    private event WeaponDelegate OnAmmoEnded;
    private event WeaponDelegate OnShoot;
    private bool once = true;

    private void Start()
    {
        OnAmmoEnded += fade.Init;
        OnShoot += (() =>
        {
            //once = false;
            shot = Instantiate(shotTexture, weapon.GetShootPos().position, Quaternion.identity);
            Destroy(shot, 0.1f);
        });
    }

    private void Update()
    {
        if (GameStateManager.instance.isPaused)
        {
            return;
        }
        if (shot)
        {
            shot.transform.position = weapon.GetShootPos().transform.position;
        }

        if (weapon.hasShot /*&& once*/)
        {
            OnShoot.Invoke();
        }

        if (weapon.hasTriggered && weapon.currentAmmo == 0)
        {
            if (fade.isFading)
            {
                StopCoroutine(fade.fadeCoroutine);
            }
            OnAmmoEnded.Invoke();
        }
    }

    /*
    IEnumerator DestroyShot(GameObject shot)
    {
        yield return new WaitForSecondsRealtime(.1f);
        Destroy(shot);
        once = true;
    } */
}
