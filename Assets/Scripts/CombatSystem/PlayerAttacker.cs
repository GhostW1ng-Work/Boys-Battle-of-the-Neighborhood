using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttacker : MonoBehaviour
{
    [SerializeField] private Enemy _currentEnemy;
    [SerializeField] private Weapon _weapon;
    [SerializeField] private float _attackCooldown;

    private float _currentTimer = 0;
    private Animator _animator;
    private PlayerInput _input;

    private void Start()
    {
        _input = GetComponent<PlayerInput>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_currentEnemy != null)
        {
            if (_currentTimer > 0)
            {
                _currentTimer -= Time.deltaTime;
            }

            if (Input.GetMouseButtonDown(0) && _currentTimer <= 0)
            {
                Attack();
            }
        }
    }

    private void Attack()
    {
        _currentEnemy.TakeDamage(_weapon.Damage);
        _animator.Play(nameof(Attack),0,0);
        _currentTimer = _attackCooldown;
    }

    public void SetInput(bool enabled)
    {
        _input.enabled = enabled;
    }

    public void SetTarget(Enemy enemy)
    {
        _currentEnemy = enemy;
    }
}
