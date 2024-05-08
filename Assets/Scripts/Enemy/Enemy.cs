using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private const string IS_DIED = "IsDied";

    [SerializeField] private float _maxHealth;

    private float _currentHealth;
    private PlayerSetter _playerSetter;
    private int _isDied = 0;

    public float MaxHealth => _maxHealth;
    public float CurrentHealth => _currentHealth;

    public event Action Died;

    private void Awake()
    {
        _currentHealth = _maxHealth;
        _playerSetter = GetComponent<PlayerSetter>();
    }

    private void Start()
    {
        if(PlayerPrefs.HasKey(name + IS_DIED))
        {
            _isDied = PlayerPrefs.GetInt(name + IS_DIED);
        }
        else
        {
            _isDied = 0;
        }

        if(_isDied == 1)
        {
            Destroy(gameObject);
        }
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
        PlayerPrefs.SetInt(name + IS_DIED, 1);
        Destroy(gameObject);
    }
}
