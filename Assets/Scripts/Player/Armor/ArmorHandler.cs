using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;
using static UnityEditor.Progress;

public class ArmorHandler : MonoBehaviour
{
    [SerializeField] private List<Armor> _armor;

    private int _armorLevel;

    private void Start()
    {
        _armor = YandexGame.savesData.armor;
        for (int i = 0; i < _armor.Count; i++)
        {
            _armor[i].gameObject.SetActive(true);
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
            if (_armor[i].ArmorType == armor.ArmorType)
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
