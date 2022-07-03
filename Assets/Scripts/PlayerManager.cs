using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] CharacterController cc;
    [SerializeField] private Animator animator;
    private float x;
    private float angle = 0;

    private void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        switch (x)
        {
            case < 0:
                angle = 180;
                break;
            case > 0:
                angle = 0;
                break;
        }
        animator.SetFloat("Speed", Mathf.Abs(cc.speed * x));
        animator.SetBool("IsJumping", !cc.IsGrounded());
        cc.Jump();
    }

    private void FixedUpdate()
    {
        cc.Move(x);
        cc.GetCharacter().rotation = Quaternion.Euler(0, angle, 0);
    }
}
