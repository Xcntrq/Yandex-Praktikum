using UnityEngine;

[DisallowMultipleComponent]
public class AssignStartPos : MonoBehaviour
{
    [SerializeField] private Transform _startPos;

    private void Start()
    {
        transform.position = _startPos.position;
    }
}