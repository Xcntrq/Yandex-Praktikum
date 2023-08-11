using System.Collections;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(TrailRenderer))]
public class TrailRendererEndShrink : MonoBehaviour
{
    [SerializeField] private float _endWidth;
    [SerializeField] private float _endAlpha;

    private IEnumerator Start()
    {
        TrailRenderer tr = GetComponent<TrailRenderer>();
        Color color = Color.white;
        float timer = 0f;
        float lerp = 0f;

        while (lerp < 1f)
        {
            timer += Time.deltaTime;
            lerp = timer / tr.time;
            tr.endWidth = Mathf.Lerp(tr.startWidth, _endWidth, lerp);
            color.a = Mathf.Lerp(1f, _endAlpha, lerp);
            tr.endColor = color;

            yield return null;
        }
    }
}