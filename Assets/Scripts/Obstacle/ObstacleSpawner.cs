using UnityEngine;

[DisallowMultipleComponent]
public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private PlayerScore _playerScore;
    [SerializeField] private Transform _obstaclePrefab;
    [SerializeField] private float _minCd;
    [SerializeField] private float _maxCd;
    [SerializeField] private float _minY;
    [SerializeField] private float _maxY;
    [SerializeField] private float _minGap;
    [SerializeField] private float _maxGap;

    private bool _isFirstSpawn;
    private float _timer;

    private void Start()
    {
        _isFirstSpawn = true;
        _timer = 0.1f;
    }

    private void Update()
    {
        _timer -= Time.deltaTime;

        if ((_timer <= 0) && !_isFirstSpawn)
        {
            _timer = Random.Range(_minCd, _maxCd);
            int pts = (_playerScore.Points + 1) / 2 + 1;
            Spawn(pts);
        }
        else if ((_timer <= 0) && _isFirstSpawn)
        {
            _timer = Random.Range(_minCd, _maxCd);
            _isFirstSpawn = false;
            int count = Random.Range(1, 3);
            Spawn(count);
        }
    }

    private void Spawn(int count)
    {
        float gap = 0f;

        for (int i = 0; i < count; i++)
        {
            Transform obstacle = Instantiate(_obstaclePrefab, transform.position, transform.rotation);
            float y = Random.Range(_minY, _maxY);
            obstacle.transform.Translate(gap, y, 0f);
            gap += Random.Range(_minGap, _maxGap);
        }
    }
}