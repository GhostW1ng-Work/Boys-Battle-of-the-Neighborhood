using UnityEngine;

public class EarnerMover : MonoBehaviour
{
    [SerializeField] private MoneyEarner _earner;
    [SerializeField] private Transform[] _points;

    private void Start()
    {
        _earner.transform.position = _points[0].position;
    }

    public void Move(int index)
    {
        _earner.transform.position = _points[index].position;
    }
}
