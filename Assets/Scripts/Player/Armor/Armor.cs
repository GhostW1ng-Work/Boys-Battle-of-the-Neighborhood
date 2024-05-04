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

    public int ArmorCount => _armorCount;
    public ArmorType ArmorType => _armorType;
}
