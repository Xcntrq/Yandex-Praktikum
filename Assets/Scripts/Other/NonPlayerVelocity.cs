using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody2D))]
public class NonPlayerVelocity : MonoBehaviour
{
    [SerializeField] private SpeedScOb _speedScOb;

    private void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector3.left * _speedScOb.Speed;
    }
}