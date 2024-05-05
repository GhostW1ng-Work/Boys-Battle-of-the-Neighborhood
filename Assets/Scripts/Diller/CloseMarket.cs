using UnityEngine;
using UnityEngine.UI;

public class CloseMarket : MonoBehaviour
{
    [SerializeField] private CanvasGroup _dillerPanel;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(DisablePanel);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(DisablePanel);
    }

    private void DisablePanel()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _dillerPanel.alpha = 0;
        _dillerPanel.interactable = false;
        _dillerPanel.blocksRaycasts = false;
    }
}
