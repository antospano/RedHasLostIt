using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuBackgroundScroll : MonoBehaviour
{
    [Range(-1.0f, 1.0f)]
    [SerializeField] private float scrollSpeed;
    private float offset = 0;
    private Material material;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        offset += scrollSpeed / 1000;
        material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
