using UnityEngine;

public class MoveTrigger : MonoBehaviour
{
    [SerializeField] private EarnerMover _mover;
    [SerializeField] private int _index;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerWallet player))
        {
            _mover.Move(_index);
        }   
    }
}
