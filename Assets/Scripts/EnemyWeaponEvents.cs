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
    //private GameObject currentShot;
    private event WeaponDelegate OnShoot;
    private bool once = true;

    private void Start()
    {
        OnShoot += (() =>
        {
            //once = false;
            if (!GameStateManager.instance.isPaused)
            {
                shot = Instantiate<GameObject>(shotTexture, weapon.GetShootPos().position, Quaternion.identity);
                
                //StartCoroutine(DestroyShot(shot));
                Destroy(shot, 0.1f);
            }
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
            if (!weapon)
            {
                Destroy(shot);
            }
            shot.transform.position = weapon.GetShootPos().transform.position + new Vector3(0, 0, -1);
        }

        if (weapon.isShooting) // && once
        {
            if (once)
            {
                OnShoot.Invoke();
                once = false; // Chiude la porta a chiave
            }
        }
        else
        {
            once = true; // Riapre la porta solo quando ha smesso di sparare
        }
    }
/*
    IEnumerator DestroyShot(GameObject shot)
    {
        currentShot = shot;
        yield return new WaitForSecondsRealtime(.1f);
        Destroy(shot);
    } */
}
