using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponButton : MonoBehaviour
{
    [SerializeField] private PlayerWallet _wallet;
    [SerializeField] private PlayerAttacker _playerAttacker;
    [SerializeField] private Weapon _weapon;
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
            _priceText.text = _price.ToString();
        }
        else
        {
            _priceText.text = "Выбрать";
        }
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    private void OnClick()
    {

        if (!_isBuyed)
        {
            if (_wallet.Money >= _price)
            {
                _wallet.SpendMoney(_price);
                _playerAttacker.SetWeapon(_weapon);
                _priceText.text = "Выбрать";
            }
        }
        else
        {
            _playerAttacker.SetWeapon(_weapon);
            _priceText.text = "Выбрать";
        }
    }

    public void SetArmorHandler(PlayerAttacker playerAttacker)
    {
        _playerAttacker = playerAttacker;
    }

    public void SetArmor(Weapon weapon)
    {
        _weapon = weapon;
    }

    public void SetPlayerWallet(PlayerWallet wallet)
    {
        _wallet = wallet;
    }
}
