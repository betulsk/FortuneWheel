using UnityEngine;
using UnityEngine.UI;

public class CollectorVisualController : MonoBehaviour
{
    [SerializeField] private Button _collectButton;

    private void Start()
    {
        _collectButton.onClick.AddListener(OnButtonClicked);
    }

    private void OnDestroy()
    {
        _collectButton.onClick.RemoveListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {

    }
}
