using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] protected bool _isTaking;

    public bool IsTaking => _isTaking;

    public virtual void Interact()
    {

    }
}
