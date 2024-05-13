using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class ArmorButton : MonoBehaviour
{
    private const string IS_BUYED = "IsBuyed";
    [SerializeField] private PlayerWallet _wallet;
    [SerializeField] private ArmorHandler _armorHandler;
    [SerializeField] private Armor _armor;
    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private TMP_Text _armoraText;
    [SerializeField] private int _price;
    [SerializeField] private int _isBuyed;
    [SerializeField] private bool _startItem = false;

    [SerializeField] private Button _button;

    public static event Action ArmorLevelChanged;

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
                switch (YandexGame.EnvironmentData.language)
                {
                    case "ru":
                        _priceText.text = "Выбрать";
                        break;
                    case "en":
                        _priceText.text = "Choose";
                        break;
                    case "tr":
                        _priceText.text = "Seçin";
                        break;
                    case "es":
                        _priceText.text = "Elija";
                        break;
                }
                PlayerPrefs.SetInt(_armor.name + IS_BUYED, 1);
                PlayerPrefs.Save();
                ArmorLevelChanged?.Invoke();
            }
        }
        else
        {
            _armorHandler.SetArmor(_armor);
            switch (YandexGame.EnvironmentData.language)
            {
                case "ru":
                    _priceText.text = "Выбрать";
                    break;
                case "en":
                    _priceText.text = "Choose";
                    break;
                case "tr":
                    _priceText.text = "Seçin";
                    break;
                case "es":
                    _priceText.text = "Elija";
                    break;
            }
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
            if (_startItem)
                _isBuyed = 1;
            else
                _isBuyed = 0;
        }

        if (_isBuyed == 0)
        {
            _priceText.text = _price.ToString();
        }
        else
        {
            switch (YandexGame.EnvironmentData.language)
            {
                case "ru":
                    _priceText.text = "Выбрать";
                    break;
                case "en":
                    _priceText.text = "Choose";
                    break;
                case "tr":
                    _priceText.text = "Seçin";
                    break;
                case "es":
                    _priceText.text = "Elija";
                    break;
            }
        }
        _armoraText.text = _armor.ArmorCount.ToString();
    }

    public void SetPlayerWallet(PlayerWallet wallet)
    {
        _wallet = wallet;
    }
} 
