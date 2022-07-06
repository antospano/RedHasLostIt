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
    private IEnumerator shootCoroutine;
    private bool pauseOnce = true;
    private bool justResumed = false;

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
        targetDist = Mathf.Abs(Vector3.Distance(transform.position, target.position));

        if (targetDist < Mathf.Pow(shootingRadius, 2))
        {
            RotateWeapon();
        }

        if (GameStateManager.instance.isPaused)
        {
            if (pauseOnce)
            {
                pauseOnce = false;
                justResumed = true;
                StopCoroutine(shootCoroutine);
                //Debug.Log("stopped: " + shootCoroutine.GetHashCode());
            }
            return;
        }

        if (!pauseOnce)
        {
            hasShot = false;
            pauseOnce = true;
        }

        if (!hasShot && targetDist < shootingRadius)
        {
            if (justResumed)
            {
                //Debug.Log("SOLO UNA VOLTA");
                justResumed = false;
                StartCoroutine(shootCoroutine);
                //Debug.Log("started: " + shootCoroutine.GetHashCode());
                return;
            }

            if (!justResumed) //FIXARE
            {
                shootCoroutine = WeaponShoot();
                hasShot = true;
                shoot = true;
                //pauseOnce = true;
                StartCoroutine(ResetShoot());
            }
            
        }
        //Debug.Log("yes");
    }

    private void RotateWeapon()
    {
        weaponDir = target.position - weaponPos.position;
        angle = Mathf.Atan2(weaponDir.y, weaponDir.x) * Mathf.Rad2Deg;

        weaponPos.rotation = Quaternion.Euler(0, angle <= 90 && angle >= -90 ? 0 : 180, angle <= 90 && angle >= -90 ? angle : -angle + 180);
    }

    private IEnumerator WeaponShoot() //TO DO: FIX
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
