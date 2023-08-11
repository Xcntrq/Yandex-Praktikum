using UnityEngine;

[DisallowMultipleComponent]
public class TreatSpawner : MonoBehaviour
{
    [SerializeField] private Transform _treatPrefab;
    [SerializeField] private float _minCd;
    [SerializeField] private float _maxCd;
    [SerializeField] private float _minY;
    [SerializeField] private float _maxY;

    private float _timer;

    private void Start()
    {
        _timer = Random.Range(_minCd, _maxCd);
    }

    private void Update()
    {
        _timer -= Time.deltaTime;

        if (_timer <= 0)
        {
            _timer = Random.Range(_minCd, _maxCd);

            Transform treat = Instantiate(_treatPrefab, transform.position, transform.rotation);
            float y = Random.Range(_minY, _maxY);
            treat.Translate(0f, y, 0f);
        }
    }
}