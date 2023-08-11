using UnityEngine;

[DisallowMultipleComponent]
public class SelfDestruct : MonoBehaviour
{
    [SerializeField] private float _timer;

    private void Start()
    {
        Destroy(gameObject, _timer);
    }
}