using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class MoneyEarner : MonoBehaviour
{
    [SerializeField] private int _currentEarnPerSecond = 0;
    [SerializeField] private float _timeForRevenue = 1;
    private int _currentMultiplier = 1;
    private float _timeLeft = 0;
    private bool _hasMagnet = false;

    public int CurrentEarnPerSecond => _currentEarnPerSecond;
    public int CurrentMultiplier => _currentMultiplier;

    public Action<int, bool> MoneyEarned;
    public Action LevelIncreased;
    public Action MultiplierChanged;

    private void Start()
    {
        _timeLeft = _timeForRevenue;
        _currentEarnPerSecond = YandexGame.savesData.currentEarnPerTime;
/*        _currentMultiplier = YandexGame.savesData.currentMultiplier;
        _hasMagnet = YandexGame.savesData.hasMagnet;
        _currentEarnPerSecond = YandexGame.savesData.earnPerSecond;*/
    }

    private void Update()
    {
        _timeLeft -= Time.deltaTime;

        if (_timeLeft < 0)
        {
            _timeLeft = _timeForRevenue;
            MoneyEarned?.Invoke(_currentEarnPerSecond * _currentMultiplier, _hasMagnet);
        }
    }

    public void IncreaseEarnPerSecond(int sum)
    {
        _currentEarnPerSecond += sum;
        YandexGame.savesData.currentEarnPerTime = _currentEarnPerSecond;
        YandexGame.SaveProgress();
    }

/*    public void DoubleMultiplier()
    {
        _currentMultiplier = 2;
        MultiplierChanged?.Invoke();
        YandexGame.savesData.currentMultiplier = _currentMultiplier;
        YandexGame.SaveProgress();
    }*/

    public void SetHasMagnet()
    {
        _hasMagnet = true;
/*        YandexGame.savesData.hasMagnet = _hasMagnet;
        YandexGame.SaveProgress();*/
    }

/*    public void TemporaryDoubleMultiplier(int multiplier)
    {
        _currentMultiplier = multiplier;
        MultiplierChanged?.Invoke();
    }

    public void TemporarySetHasMagnet(bool hasMagnet)
    {
        _hasMagnet = hasMagnet;
    }*/
}
