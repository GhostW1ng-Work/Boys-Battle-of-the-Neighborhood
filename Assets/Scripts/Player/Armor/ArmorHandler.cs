using System.Collections.Generic;
using UnityEngine;
using YG;

public class ArmorHandler : MonoBehaviour
{
    [SerializeField] private List<Armor> _armor;
    [SerializeField] private Armor _legs;

    private int _armorLevel;
    private int _pantsCount = 0;

    private void Start()
    {
        _armor = YandexGame.savesData.armor;
        if(YandexGame.savesData.armor.Count > 0)
        {
            for (int i = 0; i < _armor.Count; i++)
            {
                if (_armor[i].ArmorType == ArmorType.Pants)
                {
                    _pantsCount++;
                }

                _armor[i].gameObject.SetActive(true);
            }
            if (_pantsCount <= 0)
            {
                _armor.Add(_legs);
                _legs.gameObject.SetActive(true);
            }
        }
        else
        {
            _armor.Add(_legs);
            _legs.gameObject.SetActive(true);
        }
    }

    public int GetArmorLevel()
    {
        _armorLevel = 0;
        if(_armor.Count > 0)
        {
            for (int i = 0; i < _armor.Count; i++)
            {
                _armorLevel += _armor[i].ArmorCount;
            }
            return _armorLevel;
        }
        else
        {
            return 0;
        }
    }

    public void SetArmor(Armor armor)
    {
        for (int i = 0; i < _armor.Count; i++)
        {
            if (_armor[i].ArmorType == armor.ArmorType && !_armor[i].IsBase)
            {
                _armor[i].gameObject.SetActive(false);
                _armor.Remove(_armor[i]);
            }
        }
       
        _armor.Add(armor);
        armor.gameObject.SetActive(true);
        YandexGame.savesData.armor = _armor;
        YandexGame.SaveProgress();
    }
}
