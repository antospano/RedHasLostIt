using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FadeOut : MonoBehaviour
{
    [SerializeField] private float waitTime;
    [SerializeField] private float fadeVelocity;
    public CanvasGroup text { get; private set; }
    public float alpha { get; private set; }
    public bool isFading { get; private set; } = false;
    public Coroutine fadeCoroutine { get; private set; }

    private void Start()
    {
        text = Check.ComponentExists<CanvasGroup>(gameObject);
    }

    public void Init()
    {
        if (GameStateManager.instance.isPaused)
        {
            return;
        }
        isFading = true;
        alpha = 1;
        text.alpha = alpha;
        fadeCoroutine = StartCoroutine(FadeTime());
    }

    private IEnumerator FadeTime()
    {
        yield return new WaitForSecondsRealtime(waitTime);

        for (int i = 0; i < 255; i++)
        {
            alpha -= 0.003f;
            text.alpha = alpha;
            yield return new WaitForSecondsRealtime(fadeVelocity);
        }
        alpha = 0;
        text.alpha = alpha;
        isFading = false;
    }
}
