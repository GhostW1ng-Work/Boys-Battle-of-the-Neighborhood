using System;
using UnityEngine;

public class OpenMarket : Interactable
{
    [SerializeField] private CanvasGroup _dillerPanel;

    public static event Action MarketOpened;
    public override void Interact()
    {
        EnablePanel();
    }

    private void EnablePanel()
    {
        MarketOpened?.Invoke();
        Cursor.lockState = CursorLockMode.None;
        _dillerPanel.alpha = 1;
        _dillerPanel.interactable = true;
        _dillerPanel.blocksRaycasts = true;
    }
}
