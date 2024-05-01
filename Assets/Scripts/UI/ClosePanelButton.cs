using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ClosePanelButton : MonoBehaviour
{
    [SerializeField] private GoodCreator _goodCreator;
    [SerializeField] private PlayerInput _input;
    [SerializeField] private CanvasGroup _panel;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    private void OnClick()
    {
        _goodCreator.RemoveGoods();
        _panel.alpha = 0;
        _panel.interactable = false;
        _panel.blocksRaycasts = false;
        Cursor.lockState = CursorLockMode.Locked;
        _input.enabled = true;
    }
}
