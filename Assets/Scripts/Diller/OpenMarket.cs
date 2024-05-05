using UnityEngine;

public class OpenMarket : Interactable
{
    [SerializeField] private CanvasGroup _dillerPanel;

    public override void Interact()
    {
        EnablePanel();
    }

    private void EnablePanel()
    {
        Cursor.lockState = CursorLockMode.None;
        _dillerPanel.alpha = 1;
        _dillerPanel.interactable = true;
        _dillerPanel.blocksRaycasts = true;
    }
}
