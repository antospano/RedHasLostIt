using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    [SerializeField] private Transform weaponPos;
    [SerializeField] private Transform shootPos;
    [SerializeField] private Bullet bullet;
    [SerializeField] private float bulletScale;
    [SerializeField] private float shootForce;
    [SerializeField] private float shootDelay;
    [SerializeField] private float shootingRadius;
    public bool shoot { get; private set; } = false;
    private Transform target;
    private Bullet bulletPrefab;
    private Vector2 weaponDir;
    private float angle;
    private float targetDist;
    private bool hasShot = false;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (!target)
        {
            return;
        }
        targetDist = Mathf.Pow(target.position.x - shootPos.position.x, 2) + Mathf.Pow(target.position.y - shootPos.position.y, 2);

        if (targetDist < Mathf.Pow(shootingRadius, 2))
        {
            RotateWeapon();
        }

        if (!hasShot && targetDist < Mathf.Pow(shootingRadius, 2))
        {
            hasShot = true;
            shoot = true;
            StartCoroutine(ResetShoot());
            StartCoroutine(CannonShoot());
        }
    }

    private void RotateWeapon()
    {
        weaponDir = target.position - weaponPos.position;
        angle = Mathf.Atan2(weaponDir.y, weaponDir.x) * Mathf.Rad2Deg;

        weaponPos.rotation = Quaternion.Euler(0, angle <= 90 && angle >= -90 ? 0 : 180, angle <= 90 && angle >= -90 ? angle : -angle + 180);
    }

    private IEnumerator CannonShoot()
    {
        yield return new WaitForSecondsRealtime(shootDelay);

        bulletPrefab = Instantiate<Bullet>(bullet, shootPos.position, Quaternion.identity);
        bulletPrefab.SetSafeTag("EnemyWeapon");
        bulletPrefab.SetScale(bulletScale);
        bulletPrefab.Shoot(weaponDir.normalized, shootForce);
        hasShot = false;
    }

    private IEnumerator ResetShoot()
    {
        yield return new WaitForSecondsRealtime(.001f);
        shoot = false;
    }

    public Transform GetShootPos()
    {
        return shootPos;
    }
}
