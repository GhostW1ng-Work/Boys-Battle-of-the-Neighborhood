using System;
using UnityEngine;

public class PlayerWallet : MonoBehaviour
{
    private int _revenue = 0;
    private float _timeForRevenue = 1f;
    private float _currentTime = 0;

    public int Money { get; private set; }

    public event Action<int> MoneyChanged;

    private void Start()
    {
        Money = 0;
        _currentTime = _timeForRevenue;
        MoneyChanged?.Invoke(Money);
    }

    private void Update()
    {
        if(_revenue > 0)
        {
            if(_currentTime > 0)
            {
                _currentTime -= Time.deltaTime;
            }
            else
            {
                _currentTime = _timeForRevenue;
                AddMoney(_revenue);
            }
        }
    }

    public void AddMoney(int moneyAmount)
    {
        Money += moneyAmount;
        MoneyChanged?.Invoke(Money);
    }

    public void AddRevenue(int revenueAmount)
    {
        _revenue += revenueAmount;
    }
}
