using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmorListButton : MonoBehaviour
{
    [SerializeField] private PlayerWallet _playerWallet;
    [SerializeField] private AudioSource _target;
    [SerializeField] private AudioClip _sound;
    [SerializeField] private ItemHandler _itemHandler;
    [SerializeField] private List<ArmorButton> _armorButton;
    [SerializeField] private List<Armor> _armors;
    [SerializeField] private ArmorHandler _armorHandler;
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
        if(_itemHandler.GetButtonsCount() > 0)
        {
            _itemHandler.Clear();
        }
        if (_itemHandler.GetButtonWeaponsCount() > 0)
        {
            _itemHandler.Clear();
        }
        for (int i = 0; i < _armorButton.Count; i++)
        {
            ArmorButton newButton = Instantiate(_armorButton[i]);
            newButton.SetArmorHandler(_armorHandler);
            newButton.SetArmor(_armors[i]);
            newButton.SetPlayerWallet(_playerWallet);
            newButton.SetAudio(_target, _sound);
            newButton.transform.SetParent(_contentParent);
            _itemHandler.AddButton(newButton);
        }
    }
}
