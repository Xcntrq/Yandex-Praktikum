using UnityEngine;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
public class RespawnTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerView _))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}