using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    private int _currentHealth;

    public event Action PlayerDied;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        print(_currentHealth);
        if(_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        PlayerDied?.Invoke();
    }
}
