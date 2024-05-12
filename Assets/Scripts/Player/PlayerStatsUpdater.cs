using TMPro;
using UnityEngine;
using YG;

public class PlayerStatsUpdater : MonoBehaviour
{
    [SerializeField] private PlayerAttacker _attacker;
    [SerializeField] private ArmorHandler _armorHandler;

    [SerializeField] private TMP_Text _attackText;
    [SerializeField] private TMP_Text _armorText;

    private void OnEnable()
    {
        WeaponButton.WeaponChanged += OnWeaponChanged;
        ArmorButton.ArmorLevelChanged += OnArmorLevelChanged;
    }

    private void OnDisable()
    {
        WeaponButton.WeaponChanged -= OnWeaponChanged;
        ArmorButton.ArmorLevelChanged -= OnArmorLevelChanged;
    }

    private void Start()
    {
        int armorCount = 0;
        if(YandexGame.savesData.currentWeapon != null)
            _attackText.text = YandexGame.savesData.currentWeapon.Damage.ToString();
        else
            _attackText.text = _attacker.ArmDamage.ToString();

        if(YandexGame.savesData.armor.Count > 0)
        {
            foreach (var item in YandexGame.savesData.armor)
            {
                armorCount += item.ArmorCount;
            }
        }

        _armorText.text = armorCount.ToString();
    }

    private void OnWeaponChanged(Weapon weapon)
    {
        _attackText.text = weapon.Damage.ToString();
    }

    private void OnArmorLevelChanged()
    {
        _armorText.text = _armorHandler.GetArmorLevel().ToString();
    }
}
