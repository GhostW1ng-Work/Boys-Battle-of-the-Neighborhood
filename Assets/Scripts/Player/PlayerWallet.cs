using System;
using UnityEngine;

public class PlayerWallet : MonoBehaviour
{
    private const string PLAYER_MONEY = "playerMoney";
    public int Money { get; private set; }

    public event Action<int> MoneyChanged;

    private void Start()
    {
        if (PlayerPrefs.HasKey(PLAYER_MONEY))
        {
            Money = PlayerPrefs.GetInt(PLAYER_MONEY);
        }
        else
        {
            Money = 10000000;
        }
        MoneyChanged?.Invoke(Money);
    }

    public void AddMoney(int moneyAmount)
    {
        Money += moneyAmount;
        MoneyChanged?.Invoke(Money);
        PlayerPrefs.SetInt(PLAYER_MONEY, Money);
        PlayerPrefs.Save();
    }

    public void SpendMoney(int moneyCount)
    {
        Money -= moneyCount;
        MoneyChanged?.Invoke(Money);
        PlayerPrefs.SetInt(PLAYER_MONEY, Money);
        PlayerPrefs.Save();
    }
}
