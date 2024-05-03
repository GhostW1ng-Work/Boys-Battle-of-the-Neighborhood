using UnityEngine;

public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _attackSpeed;
    [SerializeField] private int _damage;

    private float _currentTimer;
    private PlayerSetter _playerSetter;

    private void Start()
    {
        _currentTimer = _attackSpeed;
        _playerSetter = GetComponent<PlayerSetter>();
    }

    private void Update()
    {
        if (_playerSetter.PlayerIsStay)
        {
            _currentTimer -= Time.deltaTime;
            if(_currentTimer <= 0)
            {
                _currentTimer = _attackSpeed;
                Attack();
            }
        }
    }

    private void Attack()
    {
        _animator.Play(nameof(Attack),0,0);
        _playerHealth.TakeDamage(_damage);
    }
}
