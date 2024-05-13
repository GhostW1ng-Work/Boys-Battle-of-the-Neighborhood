using System.Globalization;
using TMPro;
using UnityEngine;
using YG;

public class MoneyReceiver : MonoBehaviour
{
/*    [SerializeField] private AudioSource _target;
    [SerializeField] private AudioClip _sound;*/
    [SerializeField] private MoneyEarner _moneyEarner;
    [SerializeField] private TMP_Text _moneyText;

    private int _moneyCount = 0;

    private void Start()
    {
        _moneyCount = YandexGame.savesData.earnedMoneyCount;
        if(YandexGame.EnvironmentData.language == "ru")
            _moneyText.text = _moneyText.text = _moneyCount.ToString("#,#", CultureInfo.InvariantCulture) + " рублей";
        else
            _moneyText.text = _moneyText.text = _moneyCount.ToString("#,#", CultureInfo.InvariantCulture) + " rub";
    }

    private void OnEnable()
    {
        _moneyEarner.MoneyEarned += OnMoneyEarned;
    }

    private void OnDisable()
    {
        _moneyEarner.MoneyEarned -= OnMoneyEarned;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerWallet wallet))
        {
/*            _target.PlayOneShot(_sound);*/
            wallet.AddMoney(_moneyCount);
            _moneyCount = 0;
            if (YandexGame.EnvironmentData.language == "ru")
                _moneyText.text = _moneyText.text = _moneyCount.ToString("#,#", CultureInfo.InvariantCulture) + " рублей";
            else
                _moneyText.text = _moneyText.text = _moneyCount.ToString("#,#", CultureInfo.InvariantCulture) + " rub";
            YandexGame.savesData.earnedMoneyCount = _moneyCount;
            YandexGame.SaveProgress();
        }
    }

    private void OnMoneyEarned(int earnedMoney, bool hasMagnet)
    {
        if (!hasMagnet)
        {
            _moneyCount += earnedMoney;
            if (YandexGame.EnvironmentData.language == "ru")
                _moneyText.text = _moneyText.text = _moneyCount.ToString("#,#", CultureInfo.InvariantCulture) + " рублей";
            else
                _moneyText.text = _moneyText.text = _moneyCount.ToString("#,#", CultureInfo.InvariantCulture) + " rub";
            YandexGame.savesData.earnedMoneyCount = _moneyCount;
            YandexGame.SaveProgress();
        }
    }
}
