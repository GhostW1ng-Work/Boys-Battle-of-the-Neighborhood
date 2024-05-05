using UnityEngine;
using UnityEngine.UI;

public class ArmorButton : MonoBehaviour
{
    [SerializeField] private ArmorHandler _armorHandler;
    [SerializeField] private Armor _armor;

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
        _armorHandler.SetArmor(_armor);
    }

    public void SetArmorHandler(ArmorHandler armorHandler)
    {
        _armorHandler = armorHandler;
    }

    public void SetArmor(Armor armor)
    {
        _armor = armor;
    }
} 
