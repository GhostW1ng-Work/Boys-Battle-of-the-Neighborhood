using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponListButton : MonoBehaviour
{
    [SerializeField] private ItemHandler _itemHandler;
    [SerializeField] private List<WeaponButton> _weaponButtons;
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private PlayerAttacker _armorHandler;
    [SerializeField] private Transform _contentParent;

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
        if (_itemHandler.GetButtonWeaponsCount() > 0)
        {
            _itemHandler.Clear();
        }
        if (_itemHandler.GetButtonsCount() > 0)
        {
            _itemHandler.Clear();
        }
        for (int i = 0; i < _weaponButtons.Count; i++)
        {
            WeaponButton newButton = Instantiate(_weaponButtons[i]);
            newButton.SetArmorHandler(_armorHandler);
            newButton.SetArmor(_weapons[i]);
            newButton.transform.parent = _contentParent;
            _itemHandler.AddButton(newButton);
        }
    }
}
