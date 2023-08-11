using UnityEngine;

[CreateAssetMenu]
public class SpeedScOb : ScriptableObject
{
    [SerializeField] private float _speed;

    public float Speed => _speed;
}