using UnityEngine;
using UnityEngine.InputSystem;
using YG;

public class PlayerAttacker : MonoBehaviour
{
    [SerializeField] private Enemy _currentEnemy;
    [SerializeField] private Weapon _weapon;
    [SerializeField] private int _armDamage;
    [SerializeField] private float _attackCooldown;

    private float _currentTimer = 0;
    private Animator _animator;
    private PlayerInput _input;

    private void Start()
    {
        _input = GetComponent<PlayerInput>();
        _animator = GetComponent<Animator>();
        _weapon = YandexGame.savesData.currentWeapon;
        if(_weapon != null)
        {
            _weapon.gameObject.SetActive(true);
        }
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
        if(_weapon != null)
        {
            _currentEnemy.TakeDamage(_weapon.Damage);
        }
        else
        {
            _currentEnemy.TakeDamage(_armDamage);
        }

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

    public void SetWeapon(Weapon weapon)
    {
        if(_weapon != null)
        {
            _weapon.gameObject.SetActive(false);
        }
        _weapon = weapon;
        weapon.gameObject.SetActive(true);
        YandexGame.savesData.currentWeapon = weapon;
        YandexGame.SaveProgress();
    }
}
