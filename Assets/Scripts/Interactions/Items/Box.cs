using UnityEngine;

public class Box : Interactable
{
    [SerializeField] private Transform _boxNewPosition;

    private Rigidbody _rigidbody;
    private bool _isTaked = false;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public override void Interact()
    {
        print("Взяли ящик");
        if(_isTaked)
        {
            _isTaked = false;
            transform.parent = null;
        }
        else
        {
            _isTaked = true;
            _rigidbody.isKinematic = true;
            transform.parent = _boxNewPosition;
        }
    }
}
