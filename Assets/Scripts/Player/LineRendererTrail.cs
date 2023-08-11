using System.Collections;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(LineRenderer))]
public class LineRendererTrail : MonoBehaviour
{
    [SerializeField] private SpeedScOb _speedScOb;
    [SerializeField] private float _trailLength;
    [SerializeField] private float _minVertexDist;
    [SerializeField] private float _endWidth;
    [SerializeField] private float _endAlpha;

    private bool _isFullLength;
    private float _timer;

    private void Update()
    {
        if (!TryGetComponent(out LineRenderer lr)) return;

        Vector3[] positions = new Vector3[lr.positionCount + 1];
        lr.GetPositions(positions);

        if (!_isFullLength)
        {
            float currentLength = transform.position.x - positions[lr.positionCount - 1].x + 0.01f;
            if (currentLength > _trailLength)
            {
                _isFullLength = true;
            }
        }

        _timer += Time.deltaTime;
        float vertexTime = _minVertexDist / _speedScOb.Speed;

        if (_timer >= vertexTime)
        {
            _timer = 0f;

            if (!_isFullLength)
            {
                lr.positionCount++;
            }

            for (int i = lr.positionCount - 1; i > 0; i--)
            {
                positions[i] = positions[i - 1];
            }
        }

        int end = lr.positionCount - 1;
        for (int i = 1; i < lr.positionCount; i++)
        {
            positions[i].x -= _speedScOb.Speed * Time.deltaTime;

            if (positions[i].x < transform.position.x - _trailLength)
            {
                positions[i].x = transform.position.x - _trailLength;
                end = i;
                break;
            }
        }

        lr.positionCount = end + 1;
        positions[0] = transform.position;

        if (_isFullLength)
        {
            positions[lr.positionCount - 1].x = transform.position.x - _trailLength;
        }

        lr.SetPositions(positions);
    }

    private IEnumerator Start()
    {
        LineRenderer lr = GetComponent<LineRenderer>();
        Color color = Color.white;
        float totalTime = _trailLength / _speedScOb.Speed;
        float timer = 0f;
        float lerp = 0f;

        while (lerp < 1f)
        {
            timer += Time.deltaTime;
            lerp = timer / totalTime;
            lr.endWidth = Mathf.Lerp(lr.startWidth, _endWidth, lerp);
            color.a = Mathf.Lerp(1f, _endAlpha, lerp);
            lr.endColor = color;

            yield return null;
        }
    }
}