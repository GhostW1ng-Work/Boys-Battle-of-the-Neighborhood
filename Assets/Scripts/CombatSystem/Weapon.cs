using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float _damage;

    private Collider _collider;

    private void Start()
    {
        _collider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(_damage);
        }
    }

    public void EnableCollider(bool enabled)
    {
        _collider.enabled = enabled;
    }
}
