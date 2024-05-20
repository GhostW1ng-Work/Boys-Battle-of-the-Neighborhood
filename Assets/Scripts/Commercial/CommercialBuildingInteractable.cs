using UnityEngine;
using YG;

public class CommercialBuildingInteractable : Interactable
{
    private const string IS_BUYED = "IsBuyed";
    [SerializeField] private PlayerWallet _wallet;
    [SerializeField] private MeshRenderer[] _goods;
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

        if (_isBuyed == 1)
        {
            for (int i = 0; i < _goods.Length; i++)
            {
                _goods[i].gameObject.SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < _goods.Length; i++)
            {
                _goods[i].gameObject.SetActive(false);
            }
        }
    }

    public override void Interact()
    {
        if(_isBuyed == 0)
        {
            EnablePanel();
            switch (YandexGame.EnvironmentData.language)
            {
                case "en":
                    _buyButton.SetButton(_building.BuildingNameEn, _building.Price, _building.Revenue, this);
                    break;
                case "ru":
                    _buyButton.SetButton(_building.BuildingNameRu, _building.Price, _building.Revenue, this);
                    break;
                case "tr":
                    _buyButton.SetButton(_building.BuildingNameTr, _building.Price, _building.Revenue, this);
                    break;
                case "es":
                    _buyButton.SetButton(_building.BuildingNameEs, _building.Price, _building.Revenue, this);
                    break;
            }

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
        for (int i = 0; i < _goods.Length; i++)
        {
            _goods[i].gameObject.SetActive(true);
        }
        PlayerPrefs.SetInt(_building.BuildingName + IS_BUYED, 1);
        PlayerPrefs.Save();
    }
}
