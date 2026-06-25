using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private KeyCode jumpKey;
    [SerializeField] private float groundCheckDist;
    [SerializeField] private float jumpForce;
    [SerializeField] private float groundSpeed;
    [SerializeField] private float airSpeed;
    [SerializeField] private float groundDrag;
    [SerializeField] private float airDrag;
    [SerializeField] private Transform deathPanel;
    public float speed { get; private set; }
    public float drag { get; private set; }
    public Rigidbody2D characterRb { get; private set; }
    private bool rbSetOnce = false;
    private Vector2 saveVel;
    //private bool rbExists;
    private Transform p;

    private void Start()
    {
        p = player.GetPlayer().transform;
        characterRb = Check.ComponentExists<Rigidbody2D>(p.gameObject);

        if (deathPanel != null)
        {
            deathPanel.gameObject.SetActive(false);
        }

        if (!characterRb)
        {
            return;
        }
        //characterRb = p.GetComponent<Rigidbody2D>();
    }

    public void Move(float x)
    {
        characterRb.AddForce(new Vector3(x, 0, 0) * speed, ForceMode2D.Impulse);
    }

    public void Update()
    {
        PauseChecks();
        CheckPhysicsParams();
    }

    public void Jump()
    {
        if (Input.GetKeyDown(jumpKey))
        {
            if (IsGrounded())
            {
                characterRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapArea(transform.position - new Vector3(transform.localScale.x / 2, transform.localScale.y / 2, 0), transform.position + new Vector3(transform.localScale.x / 2, -((transform.localScale.y / 2) + groundCheckDist)), groundLayer);
    }

    public void CheckPhysicsParams()
    {
        if (!IsGrounded())
        {
            speed = airSpeed;
            drag = airDrag;
        }
        else
        {
            speed = groundSpeed;
            drag = groundDrag;
        }
        characterRb.linearDamping = drag;
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

    public Transform GetCharacter()
    {
        return p;
    }

    public Player GetPlayer()
    {
        return player;
    }

    public float GetJumpForce()
    {
        return jumpForce;
    }

    public void SetJumpForce(float force)
    {
        jumpForce = force;
    }
}
