using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int damageAmount;
    [SerializeField] private string bulletTag;
    [SerializeField] private float bulletScale;
    [SerializeField] private AudioClip piggyDamageClip;
    [SerializeField] private string boxTag;
    private Health objHealth;
    private string safeTag;
    private string checkTag;
    private Rigidbody2D rb;

    private void Start()
    {
        transform.localScale *= bulletScale;
    }

    public void Shoot(bool isEnemyShooting, Vector2 dir, float force)
    {
        rb = Check.ComponentExists<Rigidbody2D>(gameObject);
        rb.AddForce(dir * force, ForceMode2D.Impulse);
        StartCoroutine(BulletDestroy());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(bulletTag))
        {
            return;
        }
        
        checkTag = collision.gameObject.tag;
        objHealth = collision.GetComponent<Health>();

        if (checkTag != safeTag)
        {
            if (objHealth)
            {
                if (checkTag == "Piggy")
                {
                    SoundFXManager.instance.PlaySoundFX(piggyDamageClip, transform, 1.0f);
                }
                
                objHealth.SetHealth(objHealth.value - damageAmount);
            }
            Destroy(gameObject);
        }
    }

    private IEnumerator BulletDestroy()
    {
        yield return new WaitForSecondsRealtime(5);
        Destroy(gameObject);
    }

    public string GetSafeTag()
    {
        return safeTag;
    }

    public void SetSafeTag(string newTag)
    {
        safeTag = newTag;
    }

    public float GetScale()
    {
        return bulletScale;
    }

    public void SetScale(float newScale)
    {
        bulletScale = newScale;
    }
}
