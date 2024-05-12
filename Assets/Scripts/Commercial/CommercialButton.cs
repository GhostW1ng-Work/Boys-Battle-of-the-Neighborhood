using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CommercialButton : MonoBehaviour
{
    [SerializeField] private PlayerWallet _wallet;
    [SerializeField] private MoneyEarner _moneyEarner;
    [SerializeField] private CanvasGroup _buyPanel;
    [SerializeField] private TMP_Text _buildingName;
    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private TMP_Text _revenue;

    private CommercialBuildingInteractable _interactable;
    private Button _button;
    private int _currentPrice = 0;
    private int _currentRevenue = 0;

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

    public void SetButton(string buildingName, int price, int revenue, CommercialBuildingInteractable interactable)
    {
        _interactable = interactable;
        _buildingName.text = buildingName;
        _priceText.text = price.ToString();
        _revenue.text = revenue.ToString();

        _currentPrice = price;
        _currentRevenue = revenue;
    }

    private void OnClick()
    {
        if(_wallet.Money >= _currentPrice)
        {
            _interactable.SetIsBuyed();
            _wallet.SpendMoney(_currentPrice);
            _moneyEarner.IncreaseEarnPerSecond(_currentRevenue);
            DisablePanel();
        }
    }

    private void DisablePanel()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _buyPanel.alpha = 0;
        _buyPanel.blocksRaycasts = false;
        _buyPanel.interactable = false;
    }
}
