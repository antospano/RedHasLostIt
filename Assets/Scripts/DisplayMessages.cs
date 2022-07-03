using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void Message();

public class DisplayMessages : MonoBehaviour
{
    //various variables used for the events
    [SerializeField] private Weapon weapon;
    [SerializeField] private FadeOut fade;
    private event Message OnAmmoEnded;

    private void Start()
    {
        OnAmmoEnded += fade.Init;
    }

    private void Update()
    {
        if (weapon.hasShot && weapon.currentAmmo == 0)
        {
            if (fade.isFading)
            {
                StopCoroutine(fade.fadeCoroutine);
            }
            OnAmmoEnded.Invoke();
        }
    }
}
