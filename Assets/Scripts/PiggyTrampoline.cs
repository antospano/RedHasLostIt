using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiggyTrampoline : MonoBehaviour
{
    [SerializeField] private CharacterController cc;
    [SerializeField] private UpSteps upSteps;

    private float jumpForce;

    private void Start()
    {
        jumpForce = cc.GetJumpForce();
    }

    private void Update()
    {
        if (!upSteps.collisionInfo)
        {
            return;
        }

        if (upSteps.collisionInfo.gameObject.tag == "Piggy")
        {
            cc.SetJumpForce(jumpForce * 2);
            StartCoroutine(ResetJumpForce());
        }
    }

    private IEnumerator ResetJumpForce()
    {
        yield return new WaitForSecondsRealtime(.1f);
        cc.SetJumpForce(jumpForce);
    }
}
