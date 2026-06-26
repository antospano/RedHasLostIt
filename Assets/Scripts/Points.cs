using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    [SerializeField] private int setValue;
    [SerializeField] GameObject particle;
    public int value { get; private set; }

    private void Awake()
    {
        value = setValue;
    }

    public void SetPoints(int points)
    {
        value = points;
        if (particle)
        {
            Instantiate<GameObject>(particle, transform.position, Quaternion.identity);
        }
    }
}
