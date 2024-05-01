using TMPro;
using UnityEngine;

public class MoneyTextUpdater : MonoBehaviour
{
    [SerializeField] private PlayerWallet _wallet;

    private TMP_Text _moneyText;

    private void Awake()
    {
        _moneyText = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        _wallet.MoneyChanged += OnMoneyChanged;
    }

    private void OnDisable()
    {
        _wallet.MoneyChanged -= OnMoneyChanged;
    }

    private void OnMoneyChanged(int money)
    {
        _moneyText.text = money.ToString();
    }
}
