using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    bool rbSetOnce = false;
    [SerializeField] Rigidbody2D characterRb;
    Vector2 saveVel;

    private void Update()
    {
        PauseChecks();
    }

    public void PauseChecks()
    {
        if (GameStateManager.instance.isPaused)
        {
            rbSetOnce = true;
            characterRb.bodyType = RigidbodyType2D.Static;
            return;
        }
        if (rbSetOnce)
        {
            rbSetOnce = false;
            characterRb.bodyType = RigidbodyType2D.Dynamic;
            characterRb.linearVelocity = saveVel;
        }
        saveVel = characterRb.linearVelocity;
    }
}
