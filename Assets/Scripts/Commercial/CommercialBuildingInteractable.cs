using UnityEngine;

public class CommercialBuildingInteractable : Interactable
{
    private const string IS_BUYED = "IsBuyed";
    [SerializeField] private PlayerWallet _wallet;
    [SerializeField] private CommercialBuilding _building;
    [SerializeField] private CanvasGroup _buyPanel;
    [SerializeField] private CommercialButton _buyButton;

    private int _isBuyed = 0;

    private void Start()
    {
        if (PlayerPrefs.HasKey(_building.BuildingName + IS_BUYED))
        {
            _isBuyed = PlayerPrefs.GetInt(_building.BuildingName + IS_BUYED);
        }
        else
        {
            _isBuyed = 0;
        }
    }

    public override void Interact()
    {
        if(_isBuyed == 0)
        {
            EnablePanel();
            _buyButton.SetButton(_building.BuildingName, _building.Price, _building.Revenue, this);
        }
    }

    private void EnablePanel()
    {
        Cursor.lockState = CursorLockMode.None;
        _buyPanel.alpha = 1;
        _buyPanel.blocksRaycasts = true;
        _buyPanel.interactable = true;
    }
   
    public void SetIsBuyed()
    {
        _isBuyed = 1;
        PlayerPrefs.SetInt(_building.BuildingName + IS_BUYED, 1);
        PlayerPrefs.Save();
    }
}
