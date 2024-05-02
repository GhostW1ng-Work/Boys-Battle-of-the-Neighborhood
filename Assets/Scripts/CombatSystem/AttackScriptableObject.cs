using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Attacks/Normal Attack")]
public class AttackScriptableObject : ScriptableObject
{
    [SerializeField] private AnimatorOverrideController _animatorOV;

    public AnimatorOverrideController AnimatorOV => _animatorOV;
}
