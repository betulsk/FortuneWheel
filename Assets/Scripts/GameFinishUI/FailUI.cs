using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FailUI : MonoBehaviour
{
    [SerializeField] private Button _reviveButton;

    private void Start()
    {
        _reviveButton.onClick.AddListener(OnButtonClicked);
    }

    private void OnDestroy()
    {
        _reviveButton.onClick.RemoveListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
