using System;
using UnityEngine;

public class PlayerWallet : MonoBehaviour
{
    public int Money { get; private set; }

    public event Action<int> MoneyChanged;

    private void Start()
    {
        Money = 0;
        MoneyChanged?.Invoke(Money);
    }

    public void AddMoney(int moneyAmount)
    {
        Money += moneyAmount;
        MoneyChanged?.Invoke(Money);
    }

    public void SpendMoney(int moneyCount)
    {
       Money -= moneyCount;
        MoneyChanged?.Invoke(Money);
    }
}
