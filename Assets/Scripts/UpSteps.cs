using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpSteps : MonoBehaviour
{
    [SerializeField] private Transform entity;
    [SerializeField] private Collider2D checkCollider;
    [SerializeField] private LayerMask checkLayer;
    private float blockOffset;
    public bool isUp { get; private set; } = false;
    public Collider2D collisionInfo { get; private set; }
    private CharacterController cc;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Block"))
        {
            isUp = true;
            collisionInfo = collision;

            blockOffset = (collision.transform.position.y + collision.transform.localScale.y / 2) - (entity.position.y - entity.localScale.y / 2);
            entity.Translate(Vector2.up * (blockOffset + .001f));
            StartCoroutine(IsUpReset());
        }
    }

    private IEnumerator IsUpReset()
    {
        yield return new WaitForSecondsRealtime(.1f);
        collisionInfo = null;
        isUp = false;
    }    
}
