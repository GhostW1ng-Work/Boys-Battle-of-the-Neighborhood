using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ArmorButton : MonoBehaviour
{
    private const string IS_BUYED = "IsBuyed";
    [SerializeField] private PlayerWallet _wallet;
    [SerializeField] private ArmorHandler _armorHandler;
    [SerializeField] private Armor _armor;
    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private int _price;
    [SerializeField] private int _isBuyed;

    private Button _button;

    public static event Action ArmorLevelChanged;

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
        if(_isBuyed == 0)
        {
            if(_wallet.Money >= _price)
            {
                _isBuyed = 1;
                _wallet.SpendMoney(_price);
                _armorHandler.SetArmor(_armor);
                _priceText.text = "Выбрать";
                PlayerPrefs.SetInt(_armor.name + IS_BUYED, 1);
                PlayerPrefs.Save();
                ArmorLevelChanged?.Invoke();
            }
        }
        else
        {
            _armorHandler.SetArmor(_armor);
            _priceText.text = "Выбрать";
            ArmorLevelChanged?.Invoke();
        }
    }

    public void SetArmorHandler(ArmorHandler armorHandler)
    {
        _armorHandler = armorHandler;
    }

    public void SetArmor(Armor armor)
    {
        _armor = armor;
        if (PlayerPrefs.HasKey(_armor.name + IS_BUYED))
        {
            _isBuyed = PlayerPrefs.GetInt(_armor.name + IS_BUYED);
        }
        else
        {
            _isBuyed = 0;
        }

        if (_isBuyed == 0)
        {
            _priceText.text = _price.ToString();
        }
        else
        { 
            _priceText.text = "Выбрать";
        }
    }

    public void SetPlayerWallet(PlayerWallet wallet)
    {
        _wallet = wallet;
    }
} 
