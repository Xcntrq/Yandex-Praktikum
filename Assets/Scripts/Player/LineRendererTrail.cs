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

    private Vector3[] _positions;
    private int _vertexCount;
    private float _timer;

    private void Update()
    {
        if ((Time.timeScale == 0f) || !TryGetComponent(out LineRenderer lr)) return;

        _timer += Time.deltaTime;
        float vertexTime = _minVertexDist / _speedScOb.Speed;

        if (_timer >= vertexTime)
        {
            _timer = 0f;

            _vertexCount++;
            for (int i = _vertexCount - 1; i > 0; i--)
            {
                _positions[i] = _positions[i - 1];
            }
        }

        float leftmostX = transform.position.x - _trailLength;
        for (int i = 1; i < _vertexCount; i++)
        {
            _positions[i].x -= _speedScOb.Speed * Time.deltaTime;

            if (_positions[i].x < leftmostX)
            {
                float t = Mathf.InverseLerp(_positions[i].x, _positions[i - 1].x, leftmostX);
                _positions[i] = Vector3.Lerp(_positions[i], _positions[i - 1], t);
                _vertexCount = i + 1;
                break;
            }
        }

        _positions[0] = transform.position;
        lr.positionCount = _vertexCount;
        lr.SetPositions(_positions);
    }

    private IEnumerator Start()
    {
        _vertexCount = 1;
        int posCount = (int)(_trailLength / _minVertexDist) + 2;
        _positions = new Vector3[posCount];
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