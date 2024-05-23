using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private AudioClip _hitSound;
    [SerializeField] private int _maxHealth;
    [SerializeField] private ArmorHandler _armorHandler;

    private int _currentHealth;

    public int MaxHealth => _maxHealth;
    public int CurrentHealth => _currentHealth;

    public event Action PlayerDied;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    private void OnEnable()
    {
        PlayerSetter.FightEnded += OnFightEnded;   
    }

    private void OnDisable()
    {
        PlayerSetter.FightEnded -= OnFightEnded;
    }

    public void TakeDamage(int damage)
    {
        AudioSource.PlayClipAtPoint(_hitSound, transform.position);
        damage -= _armorHandler.GetArmorLevel();
        if (damage <= 0)
            damage = 1;

        _currentHealth -= damage;
        if(_currentHealth <= 0)
        {
            Die();
        }
    }

    private void OnFightEnded()
    {
        _currentHealth = _maxHealth;
    }

    private void Die()
    {
        PlayerDied?.Invoke();
        _currentHealth = _maxHealth;
    }
}
