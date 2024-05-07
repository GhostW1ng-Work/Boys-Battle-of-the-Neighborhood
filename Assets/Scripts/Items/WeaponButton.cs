using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponButton : MonoBehaviour
{
    private const string IS_BUYED = "IsBuyed";
    [SerializeField] private PlayerWallet _wallet;
    [SerializeField] private PlayerAttacker _playerAttacker;
    [SerializeField] private Weapon _weapon;
    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private int _price;
    [SerializeField] private int _isBuyed;

    private Button _button;

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

        if (_isBuyed == 0)
        {
            if (_wallet.Money >= _price)
            {
                _wallet.SpendMoney(_price);
                _playerAttacker.SetWeapon(_weapon);
                _priceText.text = "Выбрать";
                PlayerPrefs.SetInt(_weapon.name + IS_BUYED, 1);
                PlayerPrefs.Save();
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
        if (PlayerPrefs.HasKey(_weapon.name + IS_BUYED))
        {
            _isBuyed = PlayerPrefs.GetInt(_weapon.name + IS_BUYED);
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
