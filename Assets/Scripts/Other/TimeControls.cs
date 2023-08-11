using TMPro;
using UnityEngine;

[DisallowMultipleComponent]
public class TimeControls : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _hintText;

    private void Awake()
    {
        Time.timeScale = 0f;
    }

    private void Update()
    {
        if (Time.timeScale == 1) return;

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1f;
            _hintText.gameObject.SetActive(false);
        }
    }
}