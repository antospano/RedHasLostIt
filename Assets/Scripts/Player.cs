using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Weapon weapon;
    public Health health;

    public GameObject GetPlayer()
    {
        return player;
    }

    public Weapon GetWeapon()
    {
        return weapon;
    }
        
}
