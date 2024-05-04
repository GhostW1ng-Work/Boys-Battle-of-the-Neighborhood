using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private ArmorHandler _armorHandler;

    private int _currentHealth;

    public event Action PlayerDied;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        damage -= _armorHandler.GetArmorLevel();
        if (damage <= 0)
            damage = 1;
        print(damage);
        _currentHealth -= damage;
        if(_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        PlayerDied?.Invoke();
        _currentHealth = _maxHealth;
    }
}
