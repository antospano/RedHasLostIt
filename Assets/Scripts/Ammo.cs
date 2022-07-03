using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] private int setValue;
    public int value { get; private set; } = 1;

    private void Start()
    {
        value = setValue;
    }

    public void SetAmmo(int ammo)
    {
        value = ammo;
    }
}
