using UnityEngine;

public class CommercialBuildingInteractable : Interactable
{
    [SerializeField] private PlayerWallet _wallet;
    [SerializeField] private CommercialBuilding _building;
    [SerializeField] private CanvasGroup _buyPanel;
    [SerializeField] private CommercialButton _buyButton;

    private bool _isBuyed = false;

    public override void Interact()
    {

        EnablePanel();
        _buyButton.SetButton(_building.BuildingName, _building.Price, _building.Revenue);
    }

    private void EnablePanel()
    {
        Cursor.lockState = CursorLockMode.None;
        _buyPanel.alpha = 1;
        _buyPanel.blocksRaycasts = true;
        _buyPanel.interactable = true;
    }

    private void DisablePanel()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _buyPanel.alpha = 0;
        _buyPanel.blocksRaycasts = false;
        _buyPanel.interactable = false;
    }
}
