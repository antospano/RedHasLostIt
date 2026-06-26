using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Weapon weapon;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] public Health health;
    [SerializeField] public Points points;
    [SerializeField] public Ammo ammo;

    public void Start()
    {
        SoundFXManager.instance.PlaySoundFX(audioClip, transform, 1f);
    }

    public GameObject GetPlayer()
    {
        return player;
    }

    public Weapon GetWeapon()
    {
        return weapon;
    }
        
}
