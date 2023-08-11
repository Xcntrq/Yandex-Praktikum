using TMPro;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    private int _points;

    public int Points => _points;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out TreatView _))
        {
            _points++;
            _scoreText.SetText(_points.ToString());
        }
    }
}