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
        if (GameStateManager.instance.isPaused)
        {
            return;
        }
        PickupBehavior();
        if (pickedUp)
        {
            Destroy(gameObject);
        }
    }
}
