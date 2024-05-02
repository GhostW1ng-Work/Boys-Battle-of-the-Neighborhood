using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{
    [SerializeField] private List<AttackScriptableObject> _combo;
    [SerializeField] private Weapon _weapon;

    private Animator _animator;

    private float _lastClickedTime;
    private float _lastComboEnd;
    private int _comboCounter;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
        ExitAttack();
    }

    private void Attack()
    {
        if(Time.time > 0.2f && _comboCounter <= _combo.Count)
        {
            CancelInvoke(nameof(EndCombo));

            if(Time.time - _lastClickedTime >= 0.2f)
            {
                _animator.runtimeAnimatorController = _combo[_comboCounter].AnimatorOV;
                _animator.Play("Attack", 0, 0);
                _comboCounter++;

                _lastClickedTime = Time.time;

                if(_comboCounter >= _combo.Count)
                {
                    _comboCounter = 0;
                }
            }
        }
    }

    private void ExitAttack()
    {
        if(_animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.9f 
            && _animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
        {
            Invoke(nameof(EndCombo), 1);
        }
    }

    private void EndCombo()
    {
        _comboCounter = 0;
        _lastComboEnd = Time.time;
    }

    public void EnableCollider()
    {
        _weapon.EnableCollider(true);
    }

    public void DisableCollider()
    {
        _weapon.EnableCollider(false);
    }
}
