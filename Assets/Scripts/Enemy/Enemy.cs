using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    private float _currentHealth;
    private PlayerSetter _playerSetter;

    public event Action Died;

    private void Start()
    {
        _currentHealth = _maxHealth;
        _playerSetter = GetComponent<PlayerSetter>();
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        if(_currentHealth <= 0) 
        {
            Die();
        }
    }

    private void Die()
    {
        Died?.Invoke();
        Destroy(gameObject);
    }
}
