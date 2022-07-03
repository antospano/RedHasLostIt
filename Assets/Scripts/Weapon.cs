using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Bullet bullet;
    [SerializeField] private Transform shootPos;
    [SerializeField] private float shootForce;
    [SerializeField] private Ammo ammo;
    [SerializeField] private DisplayValue displayCurrentAmmo;
    [SerializeField] private int maxAmmo;
    [SerializeField] private float shootDelay;
    public int currentAmmo { get; private set; }
    public bool hasShot { get; private set; } = false;
    public bool canShoot { get; private set; } = true;
    public bool hasTriggered { get; private set; } = false;
    private Bullet bulletPrefab;

    private void Start()
    {
        currentAmmo = maxAmmo;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.F))
        {
            hasTriggered = true;
            canShoot = false;

            if (currentAmmo > 0 && canShoot)
            {
                WeaponShoot();
                hasShot = true;
                StartCoroutine(ResetShot());
                StartCoroutine(CanShoot());
            }

            StartCoroutine(ResetTrigger());
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    private void WeaponShoot()
    {
        bulletPrefab = Instantiate<Bullet>(bullet, new Vector3(shootPos.position.x, shootPos.position.y, 0), Quaternion.identity);
        bulletPrefab.Shoot(transform.right, shootForce);
        currentAmmo -= 1;
    }

    IEnumerator ResetShot()
    {
        yield return new WaitForSecondsRealtime(.001f);
        hasShot = false;
    }

    IEnumerator CanShoot()
    {
        yield return new WaitForSecondsRealtime(shootDelay);
        canShoot = true;
    }

    IEnumerator ResetTrigger()
    {
        yield return new WaitForSecondsRealtime(.001f);
        hasTriggered = false;
    }

    private void Reload()
    {
        if (ammo.value == 0 || currentAmmo == maxAmmo)
        {
            return;
        }

        float _currentAmmo = currentAmmo;
        for (int i = maxAmmo; i > _currentAmmo; i--)
        {
            if (ammo.value == 0)
            {
                return;
            }

            currentAmmo++;
            ammo.SetAmmo(ammo.value - 1);
        }
    }

    public Transform GetShootPos()
    {
        return shootPos;
    }
}
