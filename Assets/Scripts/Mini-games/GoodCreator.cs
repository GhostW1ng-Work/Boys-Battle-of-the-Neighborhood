using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoodCreator : MonoBehaviour
{
    [SerializeField] private PlayerWallet _wallet;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private ContentSizeFitter _parent;
    [SerializeField] private CanvasGroup _goodsPanel;

    [SerializeField] private Good[] _goods;
    [SerializeField] private List<Good> _createdGoods;
    [SerializeField] private int _minGoodForSpawn;
    [SerializeField] private int _maxGoodForSpawn;
    [SerializeField] private int _money;

    private int _currentSpawnedGoods = 0;
    private int _currentSpawnIndex = 0;

    private void OnEnable()
    {
        GoodTaker.GoodTaked += OnGoodTaked;
    }

    private void OnDisable()
    {
        GoodTaker.GoodTaked -= OnGoodTaked;
    }

    private void Start()
    {
        _currentSpawnedGoods = Random.Range(_minGoodForSpawn, _maxGoodForSpawn);

        for (int i = 0; i < _currentSpawnedGoods; i++)
        {
            _currentSpawnIndex = Random.Range(0, _goods.Length);
            Good good = Instantiate(_goods[_currentSpawnIndex], transform);
            good.Initialize(_canvas, _parent, _goodsPanel);
            _createdGoods.Add(good);
        }
    }

    private void OnGoodTaked(Good good)
    {
        _createdGoods.Remove(good);
        if(_createdGoods.Count <= 0)
        {
            _wallet.AddMoney(_money);
        }
    }
}
