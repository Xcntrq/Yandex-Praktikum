using UnityEngine;

[DisallowMultipleComponent]
public class ObstacleView : MonoBehaviour
{
    [SerializeField] private float _driftTime;
    [SerializeField] private float _driftAmount;
    [SerializeField] private AnimationCurve _animationCurve;

    private float _timer;

    private void Start()
    {
        _timer = Random.Range(0f, _driftTime);
    }

    void Update()
    {
        _timer += Time.deltaTime;
        _timer %= _driftTime;
        float t = _animationCurve.Evaluate(_timer / _driftTime);
        float y = Mathf.Lerp(-_driftAmount, _driftAmount, t);
        transform.localPosition = Vector2.up * y;
    }
}