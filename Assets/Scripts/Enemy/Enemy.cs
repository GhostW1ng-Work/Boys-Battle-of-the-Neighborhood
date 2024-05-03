using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    private float _currentHealth;
    private PlayerSetter _playerSetter;

    public event Action Died;

    private void Awake()
    {
        _currentHealth = _maxHealth;
        _playerSetter = GetComponent<PlayerSetter>();
    }

    private void OnEnable()
    {
        _playerSetter.PlayerLosed += OnPlayerLosed;
    }

    private void OnDisable()
    {
        _playerSetter.PlayerLosed -= OnPlayerLosed;
    }

    private void OnPlayerLosed()
    {
        _currentHealth = _maxHealth;
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
