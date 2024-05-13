using UnityEngine;

public enum ArmorType
{
    Head,
    Torso,
    Pants,
    Shoes,
    Hands
}
public class Armor : MonoBehaviour
{
    [SerializeField] private int _armorCount;
    [SerializeField] private ArmorType _armorType;
    [SerializeField] private bool _isBase = false;

    public int ArmorCount => _armorCount;
    public ArmorType ArmorType => _armorType;
    public bool IsBase => _isBase;
}
