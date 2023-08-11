using UnityEngine;

[DisallowMultipleComponent]
public class TreatView : MonoBehaviour
{
    [SerializeField] private Treat _treat;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerView _))
        {
            Destroy(_treat.gameObject);
        }
    }
}