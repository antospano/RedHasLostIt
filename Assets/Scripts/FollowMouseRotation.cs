using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouseRotation : MonoBehaviour
{
    Vector2 dir;
    float angle;
    float posAngle;
    float negAngle;

    private void Update()
    {
        if (GameStateManager.instance.isPaused)
        {
            return;
        }
        dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        /*
        negAngle = -angle + 90.0f;
        posAngle = angle + 90.0f;
        transform.rotation = Quaternion.Euler(0, negAngle < 90 ? 0 : 180, negAngle < 90 ? negAngle : posAngle); */
        transform.rotation = Quaternion.Euler(0, angle <= 189 && angle >= 0 ? 0 : 180, angle <= 180 && angle >= 0 ? -angle + 90 : angle + 90);

        /*
        yAngle = angle > 90 ? 180 : angle < 0 ? 180 : 0;
        zAngle = angle > 90 ? -angle + 180 : angle < 0 ? angle + 180 : angle;
        transform.rotation = Quaternion.Euler(0, yAngle, zAngle); */
    }
}
