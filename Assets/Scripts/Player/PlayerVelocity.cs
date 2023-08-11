using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerVelocity : MonoBehaviour
{
    [SerializeField] private SpeedScOb _speedScOb;

    private bool _isMoving;

    private void FixedUpdate()
    {
        if (_isMoving || (Time.timeScale == 0f)) return;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 vel = rb.velocity;
        vel.x = _speedScOb.Speed;
        rb.velocity = vel;
        _isMoving = true;
    }
}