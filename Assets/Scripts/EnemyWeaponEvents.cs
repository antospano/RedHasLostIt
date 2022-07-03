using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void EnemyWeaponDelegate();

public class EnemyWeaponEvents : MonoBehaviour
{
    //various variables used for the events
    [SerializeField] private EnemyWeapon weapon;
    [SerializeField] private GameObject shotTexture;
    private GameObject shot;
    private event WeaponDelegate OnShoot;
    private bool once = true;

    private void Start()
    {
        OnShoot += (() =>
        {
            once = false;
            shot = Instantiate<GameObject>(shotTexture, weapon.GetShootPos().position, Quaternion.identity);
            StartCoroutine(DestroyShot(shot));
        });
    }

    private void Update()
    {
        if (shot)
        {
            shot.transform.position = weapon.GetShootPos().transform.position;
        }

        if (weapon.shoot && once)
        {
            OnShoot.Invoke();
        }
    }

    IEnumerator DestroyShot(GameObject shot)
    {
        yield return new WaitForSecondsRealtime(.1f);
        Destroy(shot);
        once = true;
    }
}
