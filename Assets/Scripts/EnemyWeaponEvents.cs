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
    private GameObject currentShot;
    private event WeaponDelegate OnShoot;

    private void Start()
    {
        OnShoot += (() =>
        {
            //once = false;
            if (!GameStateManager.instance.isPaused)
            {
                shot = Instantiate<GameObject>(shotTexture, weapon.GetShootPos().position, Quaternion.identity);
                //Debug.Log("coc");
                StartCoroutine(DestroyShot(shot));
            }
        });
    }

    private void Update()
    {
        if (GameStateManager.instance.isPaused)
        {
            return;
        }
        if (weapon.isShooting) // && once
        {
            //Debug.Log("bruh? " + weapon.isShooting);
            OnShoot.Invoke();
        }

        if (shot)
        {
            if (!weapon)
            {
                Destroy(currentShot);
            }
            shot.transform.position = weapon.GetShootPos().transform.position + new Vector3(0, 0, -1);
        }
    }

    IEnumerator DestroyShot(GameObject shot)
    {
        currentShot = shot;
        yield return new WaitForSecondsRealtime(.1f);
        Destroy(shot);
        //once = true;
    }
}
