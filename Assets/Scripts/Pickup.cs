using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    protected int value;
    protected bool pickedUp = false;

    public virtual void PickupBehavior() { }

    private void Update()
    {
        PickupBehavior();
        if (pickedUp)
        {
            Destroy(gameObject);
        }
    }
}
