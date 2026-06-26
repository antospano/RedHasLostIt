using UnityEngine;

public class CoinMovementHandler : MonoBehaviour
{
    [SerializeField] private float speed = 3.0f;
    [SerializeField] private float amplitude = 0.5f;

    private Vector2 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float newY = startPos.y + Mathf.Sin(Time.time * speed) * amplitude;
        transform.position = new Vector2(startPos.x, newY);
    }
}
