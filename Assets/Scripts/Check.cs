using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check
{
    public static TypeComponent ComponentExists<TypeComponent>(GameObject objToCheck) where TypeComponent : Component
    {
        TypeComponent tc = objToCheck.GetComponent<TypeComponent>();

        if (!tc)
        {
            Debug.LogError("ERROR: " + tc.GetType() + " not found in " + objToCheck.name + "!");
            return tc;
        }
        return tc;
    }
}
