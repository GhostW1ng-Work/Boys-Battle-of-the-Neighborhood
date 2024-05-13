using UnityEngine;

public class TextLookAtPlayer : MonoBehaviour
{
    [SerializeField] private Camera _target;
    private void Update()
    {
        Vector3 direction = transform.position - _target.transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;
        transform.eulerAngles = new Vector3(0, rotation.eulerAngles.y, 0);
    }
}
