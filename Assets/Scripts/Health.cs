using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int setValue;
    public int value { get; private set; }

    private void Start()
    {
        value = setValue;
    }

    public void SetHealth(int health)
    {
        value = health;
    }
}
