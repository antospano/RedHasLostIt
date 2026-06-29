using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [Range(0.0f, .01f)]
    [SerializeField] private float scrollSpeed;
    [SerializeField] private CharacterController cc;
    [SerializeField] private float backgroundHeight;
    private float offset = 0;
    private Material material;

    private void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        if (cc.speed == 0)
        {
            return;
        }
        transform.position = new Vector3(Camera.main.transform.position.x, backgroundHeight, 10);
    }

    private void FixedUpdate()
    {
        if (!cc.characterRb)
        {
            return;
        }

        if (Mathf.Abs(cc.characterRb.linearVelocity.x) == 2)
        {
            return;
        }
        offset += cc.characterRb.linearVelocity.x * scrollSpeed * Time.fixedDeltaTime;
        material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
