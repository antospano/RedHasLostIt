using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;

    private void Update()
    {
        if (!target)
        {
            return;
        }

        Camera.main.transform.position = new Vector3(target.position.x, target.position.y + 2, -5);
    }
}
