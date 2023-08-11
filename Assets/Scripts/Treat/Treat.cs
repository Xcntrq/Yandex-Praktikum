using UnityEngine;

[DisallowMultipleComponent]
public class Treat : MonoBehaviour
{
    [SerializeField] private float _energyLeft;
    [SerializeField] private float _energyDecay;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerView playerView))
        {
            transform.position = Vector3.MoveTowards(transform.position, playerView.transform.position, Time.deltaTime * _energyLeft);
            _energyLeft *= _energyDecay;
        }
    }
}