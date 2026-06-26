using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Weapon weapon;
    [SerializeField] private AudioClip audioClip;
    public Health health;

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
