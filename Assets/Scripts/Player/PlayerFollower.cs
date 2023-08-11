using UnityEngine;

[DisallowMultipleComponent]
public class PlayerFollower : MonoBehaviour
{
    [SerializeField] private Transform _playerRb;
    [SerializeField] private Transform _layoutReference;

    private void LateUpdate()
    {
        Vector3 pos = transform.position;
        pos.x += _playerRb.position.x - _layoutReference.position.x;
        transform.position = pos;
    }
}