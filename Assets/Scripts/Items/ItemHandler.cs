using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandler : MonoBehaviour
{
    [SerializeField] private List<ArmorButton> _armorButtons;

    public void AddButton(ArmorButton button)
    {
        _armorButtons.Add(button);
    }

    public void Clear()
    {
        for (int i = 0; i < _armorButtons.Count; i++)
        {
            Destroy(_armorButtons[i].gameObject);
        }
        _armorButtons.Clear();
    }

    public int GetButtonsCount()
    {
        return _armorButtons.Count;
    }
}
