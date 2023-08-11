using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerControls : MonoBehaviour
{
    [SerializeField] private float _force;

    private void FixedUpdate()
    {
        if (Input.GetAxisRaw("Main") > 0)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * _force);
        }
    }
}