using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private const string IS_DIED = "IsDied";

    [SerializeField] private Animator _animator;
    [SerializeField] private AudioClip _hitSound;
    [SerializeField] private float _maxHealth;

    private float _currentHealth;
    private PlayerSetter _playerSetter;
    private int _isDied = 0;

    public float MaxHealth => _maxHealth;
    public float CurrentHealth => _currentHealth;

    public event Action Died;
    public static event Action AnyEnemyDied;

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
        AudioSource.PlayClipAtPoint(_hitSound, transform.position);
        _currentHealth -= damage;
        if(_currentHealth <= 0) 
        {
            StartCoroutine(Die());
        }
    }

    private IEnumerator Die()
    {
        Died?.Invoke();
        AnyEnemyDied?.Invoke();
        PlayerPrefs.SetInt(name + IS_DIED, 1);
        _animator.SetTrigger("Dead");
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
