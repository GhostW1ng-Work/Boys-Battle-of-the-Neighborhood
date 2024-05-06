using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponButton : MonoBehaviour
{
    [SerializeField] private PlayerAttacker _playerAttacker;
    [SerializeField] private Weapon _weapon;

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
        _playerAttacker.SetWeapon(_weapon);
    }

    public void SetArmorHandler(PlayerAttacker playerAttacker)
    {
        _playerAttacker = playerAttacker;
    }

    public void SetArmor(Weapon weapon)
    {
        _weapon = weapon;
    }
}
