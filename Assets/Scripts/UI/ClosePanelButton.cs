using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ClosePanelButton : MonoBehaviour
{
    [SerializeField] private GoodCreator _goodCreator;
    [SerializeField] private PlayerInput _input;
    [SerializeField] private CanvasGroup _panel;

    private Button _button;

    public static event Action MinigameClosed;

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
        MinigameClosed?.Invoke();
        _goodCreator.RemoveGoods();
        _panel.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        _input.enabled = true;
    }
}
