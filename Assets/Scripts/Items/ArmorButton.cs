using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ArmorButton : MonoBehaviour
{
    [SerializeField] private PlayerWallet _wallet;
    [SerializeField] private ArmorHandler _armorHandler;
    [SerializeField] private Armor _armor;
    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private int _price;
    [SerializeField] private bool _isBuyed = false;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void Start()
    {
        _isBuyed = false;
        if (_isBuyed)
            _priceText.text = "Выбрать";
        else
            _priceText.text = _price.ToString();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
        if (!_isBuyed)
        {
            if (_wallet.Money >= _price)
            {
                _wallet.SpendMoney(_price);
                _armorHandler.SetArmor(_armor);
                _priceText.text = "Выбрать";
            }
        }
        else
        {
            _armorHandler.SetArmor(_armor);
            _priceText.text = "Выбрать";
        }
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    private void OnClick()
    {
        if(!_isBuyed)
        {
            if(_wallet.Money >= _price)
            {
                _wallet.SpendMoney(_price);
                _armorHandler.SetArmor(_armor);
                _priceText.text = "Выбрать";
            }
        }
        else
        {
            _armorHandler.SetArmor(_armor);
            _priceText.text = "Выбрать";
        }
    }

    public void SetArmorHandler(ArmorHandler armorHandler)
    {
        _armorHandler = armorHandler;
    }

    public void SetArmor(Armor armor)
    {
        _armor = armor;
    }

    public void SetPlayerWallet(PlayerWallet wallet)
    {
        _wallet = wallet;
    }
} 
