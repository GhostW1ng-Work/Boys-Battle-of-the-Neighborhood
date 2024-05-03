using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private int _damage;

    public int Damage => _damage;
}
